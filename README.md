This is a peer-to-peer digital asset transfer simulation project on a sample blockchain protocol.

## Table of Contents

* [Overview](https://github.com/salihcemil/WalletApp#overview)
* [Dependencies](https://github.com/salihcemil/WalletApp#dependencies)
* [Running Order](https://github.com/salihcemil/WalletApp#running-order)
* [Cryptography](https://github.com/salihcemil/WalletApp#cryptography)
* [Transactions](https://github.com/salihcemil/WalletApp#transactions)
* [Assets](https://github.com/salihcemil/WalletApp#assets)
* [Consensus](https://github.com/salihcemil/WalletApp#consensus)
* [Communication Between Nodes](https://github.com/salihcemil/WalletApp#communication-between-nodes)
* [Limitations](https://github.com/salihcemil/WalletApp#limitations)

## Overview

The project consists of 3 different pieces of applications.

* Dispatcher: The application which simulates the p2p network. The project is not on a real p2p network but it has a central dispatcher application as a broadcaster to all wallets and miner apps.
* Wallet: Basic user/digital asset owner application which is only be able to sends and receives assets. Wallet applications listen to the network for new blocks to update their ledger.
* Miner: Proof-of-Work provider on the network. Miner applications listen to the network for both new transactions and new blocks, try to find nonce value and when succeeded publish a new block to the network. In this project, miners work manually to validate by pushing the mine button.

## Dependencies

In this project, [MongoDB](https://www.mongodb.com/) is used as a database. In order to run the project, the environment must contain MongoDB and mongo server must be run before applications.

Each wallet and miner application has its own database. Applications read connection information from "connectionString" and "dbName" fields in <appSettings> section stored in app.config file.

## Running Order

Since wallet and miner applications have their own database on MongoDB, they will try to connect to DB at the beginning. They also need to connect to the network which means finding a dispatcher application. In order to run wallet and miner applications, the order below must be followed:

* Primarily mongo server is run.
* Secondarily dispatcher app is run.
* Finally miner and wallet applications can be run.

## Cryptography

In this project, SHA256 is used as a hash function and ECDSA to sign transactions. Transactions cannot be created without a signature and signatures cannot be created without a public-private key pair. Like connection info, applications also get their private and public keys from app.config file under the <appSettings> section. 
  
Each application must have its own public and private key. So, in order to create these key pairs, a Keygen application will be helpful. For digital signature and public-private keypair creation, [babel licensing](http://www.babelfor.net/) is used.

## Transactions

Transactions basically must have a valid amount, a sender, a receiver and a valid digital signature on them. In the project, the transaction mechanism is based on Satoshi's [mint based transaction approach](https://bitcoin.org/bitcoin.pdf). 

## Assets

As mentioned above, the mint-based transaction model is used in this project. This means, in each transaction, input assets are killed which were assigned to the sender and new assets are created and assigned to the receiver. Assets must be assigned to a user thus only the owner can use them in a transaction as an input.

## Consensus

Since it is based on Bitcoin's Blockchain, the Proof of Work is used. The difficulty index is symbolically and hardcoded set to "5" in the miner class. Blocks are simply serialized and nonce value is added to the end of it and programmatically increased for mining.

## Communication Between Nodes

The dispatcher app is responsible for the communication. It gets messages and broadcasts them to the clients who are connected. In order to get this real-time messaging feature, we used classic client-server architecture by using [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr).

## Limitations

The project is a sample to examine blockchain basics. First of all, a blockchain protocol is a Distributed Ledger Technology. And to distribute the ledgers, they must be set on a real p2p network. Although p2p networks are vital for DLT, there is no advancement in it with blockchain protocols. Because of that, the project mimics a p2p network.

In PoW based protocols, difficulty should be updated dynamically in specific periods. In this project, difficulty updates are ignored.

Also, public-key/address validations and mining rewards are ignored to examine the main points of a protocol. Since there are no mining rewards, assets must be set at the beginning of the protocol and assigned to the users' public keys in the genesis block.
