// See https://aka.ms/new-console-template for more information
using NBitcoin;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");
bool runging = true;
NetworkCredential networkCredential = new NetworkCredential("rootbtc", "bitcoin@xbk");
while (runging)
{
	try { 

		NBitcoin.RPC.RPCCredentialString rPCCredentialString = new NBitcoin.RPC.RPCCredentialString();
		//rPCCredentialString.Server = "";
		
		rPCCredentialString.UserPassword = networkCredential;
		var rPCClient = new NBitcoin.RPC.RPCClient(rPCCredentialString, "34.64.34.63:8332", Network.Main);

		var blkCount = await rPCClient.GetBlockCountAsync();

		var v2 = rPCClient.GetBlock(blkCount);

		
		//var transacs = rPCClient.GetTransactions(v2.GetHash()).ToList();


		//var mempool = rPCClient.GetMemPool();

		//var rawmempool = rPCClient.GetRawMempool();

		// transaction on memo
		//var tranc = rPCClient.GetRawTransactionInfo(uint256.Parse("ab433f6908c3665796974d1ca1c454e75a3bbeca352dac669fd7aea8ca9a1e42"));

		var blinfo = rPCClient.GetBlockchainInfo();
		
		rPCCredentialString.WalletName = "Default_Admin";
		var transacs = rPCClient.ListWalletTransactions("*",10, 0);


		//from wallet transsaction


		//00000000000000000000d551ea4f7d281599cad0839389f011c6aa07436d90c2
		var bestblock = blinfo.BestBlockHash;



		int blockcount = rPCClient.GetBlockCount();

		var block = rPCClient.GetBlock(bestblock);
		
		var firstTx = block.Transactions.First();

		//var txInfo = rPCClient.GetRawTransactionInfo(firstTx.GetHash());

		foreach(var tran in block.Transactions)
		{
			var hexstring = tran.ToHex();
		}
		// require for wallet
		
		var addressinfo = rPCClient.GetAddressInfo(BitcoinAddress.Create("bc1q3vukw3ymgfey6vf2xmtkntrl30ug78r2hprfql",Network.Main));//new IDestination "bc1q3vukw3ymgfey6vf2xmtkntrl30ug78r2hprfql");


		var scan = rPCClient.ScanRPCCapabilities();

		var ballance = rPCClient.GetBalance();
		//var newlegacyaddress = await rPCClient.GetNewAddressAsync(new NBitcoin.RPC.GetNewAddressRequest() { AddressType = NBitcoin.RPC.AddressType.Legacy, Label = "Legacy" }, new CancellationToken());
		//1Go2VDPFaPQ3AZbgLLXBPTZC1xZ5g2SuGV
		//var newP2SHSegwitaddress = await rPCClient.GetNewAddressAsync(new NBitcoin.RPC.GetNewAddressRequest() { AddressType = NBitcoin.RPC.AddressType.P2SHSegwit, Label = "P2SHSegwit" }, new CancellationToken());
		//3L2MXzobGe5xT3roDhz7o3PGus9K2SEkRa
		//var newBech32address = await rPCClient.GetNewAddressAsync(new NBitcoin.RPC.GetNewAddressRequest() { AddressType = NBitcoin.RPC.AddressType.Bech32, Label = "Bech32" }, new CancellationToken());
		//bc1q3vukw3ymgfey6vf2xmtkntrl30ug78r2hprfql
		Console.WriteLine("Balance = " + ballance.ToString());
		//var blockchaininfo = rPCClient.SendCommand("getblockchaininfo");




	}
	catch(Exception ex)
	{

	}
	Console.WriteLine(DateTime.Now.ToString());

	Thread.Sleep(1000);
}




