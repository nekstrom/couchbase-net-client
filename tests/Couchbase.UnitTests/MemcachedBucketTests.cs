using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Core.Configuration.Server;
using Couchbase.Core.Configuration.Server.Streaming;
using Couchbase.Core.IO;
using Couchbase.UnitTests.Utils;
using Couchbase.Utils;
using Moq;
using Xunit;

namespace Couchbase.UnitTests
{
    public class MemcachedBucketTests
    {
        [Fact]
        public void ViewIndexes_Throws_NotSupportedException()
        {
            var bucket = new MemcachedBucket("default", new ClusterOptions(), new ConfigContext(new ClusterOptions()));

            Assert.Throws<NotSupportedException>(() => bucket.ViewIndexes);
        }

        [Fact]
        public async Task ViewQueryAsync_Throws_NotSupportedException()
        {
            var bucket = new MemcachedBucket("default", new ClusterOptions(), new ConfigContext(new ClusterOptions()));

            await Assert.ThrowsAsync<NotSupportedException>(async () =>
            {
                await bucket.ViewQueryAsync<dynamic>("designDoc", "viewName").ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        [Fact]
        public async Task Indexer_Throws_NotSupportedException_When_Name_Is_Not_Default()
        {
            var bucket = new MemcachedBucket("default", new ClusterOptions(), new ConfigContext(new ClusterOptions()));

            await Assert.ThrowsAsync<NotSupportedException>(async () => { await bucket["xxxxx"].ConfigureAwait(false); }).ConfigureAwait(false);
        }

        [Fact(Skip = "Will be enabled in later commit.")]
        public async Task Indexer_Succeeds_When_Name_Is_Default()
        {
            var localhost = new Uri("http://10.112.192.102:8091");
            var bucketConfig = ResourceHelper.ReadResource<BucketConfig>("mycache.json");
            bucketConfig.Nodes.RemoveAt(1);

            var mockClusterNode = new Mock<IClusterNode>();
            mockClusterNode.Setup(x => x.EndPoint).Returns(localhost.GetIpEndPoint(8091, false));
            mockClusterNode.Setup(x => x.BootstrapUri).Returns(localhost);
            mockClusterNode.Setup(x => x.SelectBucket("default")).Returns(Task.CompletedTask);

            var mockHttpClusterMap = new Mock<HttpClusterMapBase>();
            mockHttpClusterMap.Setup(x =>
                x.GetClusterMapAsync("default", localhost, CancellationToken.None)).
                Returns(Task.FromResult(bucketConfig));

            var bucket = new MemcachedBucket("default", new ClusterOptions(), new ConfigContext(new ClusterOptions()), mockHttpClusterMap.Object);
            await bucket.Bootstrap(mockClusterNode.Object).ConfigureAwait(false);

            var scope = await bucket[BucketBase.DefaultScope].ConfigureAwait(false);
            Assert.Equal(BucketBase.DefaultScope, scope.Name);
        }

        [Fact(Skip = "Will be enabled in later commit.")]
        public async Task ScopeAsync_Succeeds_When_Name_Is_Default()
        {
            var localhost = new Uri("http://10.112.192.102:8091");
            var bucketConfig = ResourceHelper.ReadResource<BucketConfig>("mycache.json");
            bucketConfig.Nodes.RemoveAt(1);

            var mockClusterNode = new Mock<IClusterNode>();
            mockClusterNode.Setup(x => x.EndPoint).Returns(localhost.GetIpEndPoint(8091, false));
            mockClusterNode.Setup(x => x.BootstrapUri).Returns(localhost);
            mockClusterNode.Setup(x => x.SelectBucket("default")).Returns(Task.CompletedTask);

            var mockHttpClusterMap = new Mock<HttpClusterMapBase>();
            mockHttpClusterMap.Setup(x =>
                    x.GetClusterMapAsync("default", localhost, CancellationToken.None)).
                Returns(Task.FromResult(bucketConfig));

            var bucket = new MemcachedBucket("default", new ClusterOptions(), new ConfigContext(new ClusterOptions()), mockHttpClusterMap.Object);
            await bucket.Bootstrap(mockClusterNode.Object).ConfigureAwait(false);

            var scope = await bucket.ScopeAsync(BucketBase.DefaultScope).ConfigureAwait(false);
            Assert.Equal(BucketBase.DefaultScope, scope.Name);
        }

        [Fact(Skip = "Will be enabled in later commit.")]
        public async Task ScopeAsync_Throws_NotSupportedException_When_Name_Is_Not_Default()
        {
            var localhost = new Uri("http://10.112.192.102:8091");
            var bucketConfig = ResourceHelper.ReadResource<BucketConfig>("mycache.json");
            bucketConfig.Nodes.RemoveAt(1);

            var mockClusterNode = new Mock<IClusterNode>();
            mockClusterNode.Setup(x => x.EndPoint).Returns(localhost.GetIpEndPoint(8091, false));
            mockClusterNode.Setup(x => x.BootstrapUri).Returns(localhost);
            mockClusterNode.Setup(x => x.SelectBucket("default")).Returns(Task.CompletedTask);

            var mockHttpClusterMap = new Mock<HttpClusterMapBase>();
            mockHttpClusterMap.Setup(x =>
                    x.GetClusterMapAsync("default", localhost, CancellationToken.None)).
                Returns(Task.FromResult(bucketConfig));

            var bucket = new MemcachedBucket("default", new ClusterOptions(), new ConfigContext(new ClusterOptions()), mockHttpClusterMap.Object);
            await bucket.Bootstrap(mockClusterNode.Object).ConfigureAwait(false);

            await Assert.ThrowsAsync<NotSupportedException>(async () =>
            {
                await bucket.ScopeAsync("xxxx").ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
