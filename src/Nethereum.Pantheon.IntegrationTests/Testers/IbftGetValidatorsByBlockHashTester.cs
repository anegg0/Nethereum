

using System;
using System.Threading.Tasks;
using Nethereum.Pantheon.RPC.IBFT;
using Nethereum.JsonRpc.Client;
using Nethereum.Pantheon.IntegrationTests;
using Nethereum.RPC.Tests.Testers;
using Newtonsoft.Json.Linq;
using Xunit;
using Nethereum.Hex.HexTypes;

namespace Nethereum.Pantheon.Tests.Testers
{

    public class IbftGetValidatorsByBlockHashTester : RPCRequestTester<string[]>, IRPCRequestTester
    {
        public override async Task<string[]> ExecuteAsync(IClient client)
        {
            var web3 = new Web3.Web3(client);
            var block = await  web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(1));
            var blockHash = block.BlockHash;
            var ibftGetValidatorsByBlockHash = new IbftGetValidatorsByBlockHash(client);
            return await ibftGetValidatorsByBlockHash.SendRequestAsync(blockHash);
        }

        public override Type GetRequestType()
        {
            return typeof(IbftGetValidatorsByBlockHash);
        }

        [Fact]
        public async void ShouldReturnNotNull()
        {
            var result = await ExecuteAsync();
            Assert.NotNull(result);
        }
    }

}
        