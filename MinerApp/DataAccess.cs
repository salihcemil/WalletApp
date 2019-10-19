using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;
using MongoDB.Bson.Serialization;
using Business.Models;

namespace MinerApp
{
    public class DataAccess
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private string connectionString = ConfigurationManager.AppSettings["connectionString"];
        private string dbName = ConfigurationManager.AppSettings["dbName"];
        public string headerTableName = "Blk";
        public string trxTableName = "Trx";
        public string blkTrxTableName = "Blk_trx";
        public string inputTableName = "Input";
        public string outputTableName = "Output";



        public List<Output> getOutputListByAddress(string address)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);

            var collection = _database.GetCollection<BsonDocument>(outputTableName);
            List<BsonDocument> document = collection.Find<BsonDocument>(new BsonDocument()).ToList();

            List<Output> outputList = new List<Output>();

            foreach (var item in document)
            {
                if (item["ScriptSignKey"] == address)
                {
                    item.Remove("_id");
                    outputList.Add(BsonSerializer.Deserialize<Output>(item, null));
                }
            }

            return outputList;
        }

        public List<Output> getOutputList()
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);

            var collection = _database.GetCollection<BsonDocument>(outputTableName);
            List<BsonDocument> document = collection.Find<BsonDocument>(new BsonDocument()).ToList();

            List<Output> outputList = new List<Output>();

            foreach (var item in document)
            {
                item.Remove("_id");
                outputList.Add(BsonSerializer.Deserialize<Output>(item, null));
            }

            return outputList;
        }

        public Output getOutput(string trxId, int index)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);

            var collection = _database.GetCollection<BsonDocument>(outputTableName);
            var filter = Builders<BsonDocument>.Filter.Eq("OutputHash", trxId);
            var outputList = collection.Find(filter).ToList();
            List<Output> outputListOfTransaction = new List<Output>();

            foreach (var item in outputList)
            {
                item.Remove("_id");
                outputListOfTransaction.Add(BsonSerializer.Deserialize<Output>(item, null));
            }

            Output outp = new Output();
            outp = outputListOfTransaction.Where(x => x.OutputIndex == index).FirstOrDefault();

            return outp;
        }
        public decimal getBalance(string publicKey)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);

            var collection = _database.GetCollection<BsonDocument>("txouts");
            List<BsonDocument> document = collection.Find<BsonDocument>(new BsonDocument()).ToList();

            List<Output> outputList = new List<Output>();

            foreach (var item in document)
            {
                if (item["ScriptSignKey"] == publicKey)
                {
                    item.Remove("_id");
                    outputList.Add(BsonSerializer.Deserialize<Output>(item, null));
                }
            }

            if (outputList.Count > 0)
            {
                return outputList.Sum(x => x.Value);
            }
            else
            {
                return 0;
            }

        }
        public bool insertBlock(Block blk)
        {
            try
            {
                _client = new MongoClient(connectionString);
                _database = _client.GetDatabase(dbName);

                BsonDocument header = blk.BlockHeader.ToBsonDocument();
                var headerCollection = _database.GetCollection<BsonDocument>(headerTableName);
                headerCollection.InsertOne(header);

                var blkTrxCollection = _database.GetCollection<BsonDocument>(blkTrxTableName);
                Blk_trx blkTrx;
                BsonDocument blkTrxBson;
                BsonDocument transaction;
                var trxCollection = _database.GetCollection<BsonDocument>(trxTableName);
                for (int i = 0; i < blk.Transactions.Count; i++)
                {
                    transaction = blk.Transactions[i].ToBsonDocument();
                    trxCollection.InsertOne(transaction);

                    blkTrx = new Blk_trx
                    {
                        BlockId = blk.BlockID,
                        Index = i,
                        TransactionId = blk.Transactions[i].Hash
                    };
                    blkTrxBson = blkTrx.ToBsonDocument();
                    blkTrxCollection.InsertOne(blkTrxBson);
                }

                BsonDocument input;
                var inputCollection = _database.GetCollection<BsonDocument>(inputTableName);
                foreach (var item in blk.Transactions)
                {
                    foreach (var inp in item.Inputs)
                    {
                        input = inp.ToBsonDocument();
                        inputCollection.InsertOne(input);
                    }
                }

                BsonDocument output;
                var outputCollection = _database.GetCollection<BsonDocument>(outputTableName);
                foreach (var item in blk.Transactions)
                {
                    foreach (var outp in item.Outputs)
                    {
                        output = outp.ToBsonDocument();
                        outputCollection.InsertOne(output);
                    }
                }

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool updateOutputs(Block blk)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);

            BsonDocument header = blk.BlockHeader.ToBsonDocument();
            var outputCollection = _database.GetCollection<BsonDocument>(outputTableName);

            foreach (var trx in blk.Transactions)
            {
                foreach (var inp in trx.Inputs)
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("OutputHash", inp.PrevTransactionHash);
                    filter = filter & (Builders<BsonDocument>.Filter.Eq("OutputIndex", inp.OutputIndex.ToString()));
                    outputCollection.DeleteOne(filter);
                }
            };

            return true;
        }

        public Output getSingleOutputById(string outputId)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);
            var collection = _database.GetCollection<BsonDocument>(outputTableName);

            Output outp = new Output();

            var filter = Builders<BsonDocument>.Filter.Eq("OutputHash", outputId);
            var result = collection.Find(filter).ToList().FirstOrDefault();

            outp = BsonSerializer.Deserialize<Output>(result, null);

            return outp;
        }

        public Transaction getSingleTransactionById(string transactionId)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);
            var collection = _database.GetCollection<BsonDocument>(trxTableName);

            Transaction trx = new Transaction();

            var filter = Builders<BsonDocument>.Filter.Eq("Hash", transactionId);
            var result = collection.Find(filter).ToList().FirstOrDefault();

            trx = BsonSerializer.Deserialize<Transaction>(result, null);

            return trx;
        }

        public Header getLatestBlockHeader()
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);
            var collection = _database.GetCollection<BsonDocument>(headerTableName);
            List<BsonDocument> document = collection.Find<BsonDocument>(new BsonDocument()).ToList();

            List<Header> headers = new List<Header>();
            foreach (var item in document)
            {
                item.Remove("_id");
                headers.Add(BsonSerializer.Deserialize<Header>(item, null));
            }

            Header header = new Header();

            header = headers.OrderByDescending(i => i.ID).FirstOrDefault();

            return header;  
        }

        

        ///
        /// ***MONGODB AND OR FILTER BUILDERS***
        ///
        //var filter = Builders<Output>.Filter.Eq(x => x.OutputHash, "12345");
        //filter = filter & (Builders<Output>.Filter.Eq(x => x.OutputIndex, 0) | Builders<Output>.Filter.Eq(x => x.OutputIndex, 1));

    }
}
