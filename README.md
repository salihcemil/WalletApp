# WalletApp

This is a peer-to-peer digital asset transfer simulation project on a sample blockchain protocol.

## Overview

The project consists of 3 different type of applications.

* Dispatcher: The application which simulates p2p network. The project is not on a real p2p network but it has a central dispatcher application as a broadcaster to all wallets and miner apps.
* Wallet: Basic user/digital asset owner application which is only be able to sends and receives assets. Wallet applications listen network for new blocks to update their ledger.
* Miner: Proof-of-Work provider on the network. Miner applications listen network for both new transactions and new blocks, try to find nonce value and when succeeded publishes new block to the network. In this project, miners work manually by validate and mine buttons.

## Dependencies

In this project, MongoDB is used as a database. In order to run the project, the environment must contain mongoDb and mongo server must be run before applications.

Each wallet and miner applications has their own databases. Applications read connection information from "connectionString" and "dbName" fields in <appSettings> section stored in app.config file.

## Running Order

Since wallet and miner applciations has their own database on mongoDB, they will try to connect to db at the beginning. They also need to connect to network which means to find dispatcher application. In order to run wallet and miner applications, the order below must be followed:

* Primarily mongo server is run.
* Secondarily dispatcher app is run.
* Finally miner and wallet applications can be run.

## Cryptography

In this project, SHA256 is used as hash function and ECDSA to sign transactions. Transactions cannot be created without signature and signatures cannot be created without a public-private key pair. Like connection info, applications also gets their private and public keys from app.config file under <appSettings> section. 
  
Each applcation must have their own public and private key. So in order to create these key pairs, a Keygen application will be helpful.

## Transactions

Transactions basicaly must have a valid amount, a sender, a receiver and a valid digital signature on it. In the project, transaction mechanism is based on Satoshi's mint based transaction approach. 

## Assets

As it mentioned above, mint based transaction is used. This means, in each transaction, input assets are killed which are assigned to sender and new assets are created and assigned to receiver. Assets must be assigned to a user thus only the owner can be use it in a transaction as an input.

## Consensus

Since it is based on Bitcoin's Blockchain, the Proof of Work is used. Difficulty index is symbolically and hardcodedly set to "5" in miner class in business project. Blocks are simply serialized and nonce value is added to the end of it and programatically increasing for mining.

## Limitations

The project is a sample to examine blockchain basics. First of all, a blockchain protocol is a Distributed Ledger Technology. And to distribute the ledgers, it must be set on a real p2p network. Although p2p networks are vital for DLT, there is not an advanced about it with blockchain protocols. Because of that, the project mimics as a p2p network.

In PoW based protocols, difficulty should be updated dynamically in specific periods. In this project, difficult updates are ignored.

Also other public key validations, mining rewards are ignored to examine main points of a protocol. Since there is no mining rewards, assets must be set at the begining of the protocol and assigned to the users' public keys in the genesis block.



