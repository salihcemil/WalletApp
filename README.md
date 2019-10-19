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




