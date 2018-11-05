﻿//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define KV_MEMBER(member) s(member, #member);

using CryptoNote;
using System;
using System.Collections.Generic;
using System.Diagnostics;

// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
//
// This file is part of Bytecoin.
//
// Bytecoin is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Bytecoin is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with Bytecoin.  If not, see <http://www.gnu.org/licenses/>.

// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
//
// This file is part of Bytecoin.
//
// Bytecoin is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Bytecoin is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with Bytecoin.  If not, see <http://www.gnu.org/licenses/>.



//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CRYPTO_MAKE_COMPARABLE(type) namespace Crypto { inline bool operator==(const type &_v1, const type &_v2) { return std::memcmp(&_v1, &_v2, sizeof(type)) == 0; } inline bool operator!=(const type &_v1, const type &_v2) { return std::memcmp(&_v1, &_v2, sizeof(type)) != 0; } }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CRYPTO_MAKE_HASHABLE(type) CRYPTO_MAKE_COMPARABLE(type) namespace Crypto { static_assert(sizeof(size_t) <= sizeof(type), "Size of " #type " must be at least that of size_t"); inline size_t hash_value(const type &_v) { return reinterpret_cast<const size_t &>(_v); } } namespace std { template<> struct hash<Crypto::type> { size_t operator()(const Crypto::type &_v) const { return reinterpret_cast<const size_t &>(_v); } }; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CN_SOFT_SHELL_ITER (CN_SOFT_SHELL_MEMORY / 2)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CN_SOFT_SHELL_PAD_MULTIPLIER (CN_SOFT_SHELL_WINDOW / CN_SOFT_SHELL_MULTIPLIER)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CN_SOFT_SHELL_ITER_MULTIPLIER (CN_SOFT_SHELL_PAD_MULTIPLIER / 2)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define ENDL std::endl

namespace std
{
//C++ TO C# CONVERTER TODO TASK: C++ template specialization was removed by C++ to C# Converter:
//ORIGINAL LINE: struct hash<System.Tuple<CryptoNote::IBlockchainCache::Amount, uint32_t>>
public partial class hash
{

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t operator ()(const System.Tuple<CryptoNote::IBlockchainCache::Amount, uint32_t>& arg) const
  public static size_t functorMethod(Tuple<CryptoNote.IBlockchainCache.Amount, uint32_t> arg)
  {
	size_t hashValue = boost::hash_value(arg.Item1);
	boost::hash_combine(hashValue, arg.Item2);
	return hashValue;
  }
}

//C++ TO C# CONVERTER TODO TASK: C++ template specialization was removed by C++ to C# Converter:
//ORIGINAL LINE: struct hash<System.Tuple<Crypto::Hash, uint32_t>>
public partial class hash
{

//C++ TO C# CONVERTER TODO TASK: The typedef 'argment_type' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
//C++ TO C# CONVERTER TODO TASK: The typedef 'result_type' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: result_type operator ()(const argment_type& arg) const
  public static result_type functorMethod(argment_type arg)
  {
	size_t hashValue = new std::hash<Crypto.Hash>({})(arg.first);
	boost::hash_combine(hashValue, arg.second);
	return hashValue;
  }
}
}

namespace CryptoNote
{


public class BlockchainReadState
{
  public Dictionary<uint32_t, List<Crypto.KeyImage>> spentKeyImagesByBlock = new Dictionary<uint32_t, List<Crypto.KeyImage>>();
  public Dictionary<Crypto.KeyImage, uint32_t> blockIndexesBySpentKeyImages = new Dictionary<Crypto.KeyImage, uint32_t>();
  public Dictionary<Crypto.Hash, ExtendedTransactionInfo> cachedTransactions = new Dictionary<Crypto.Hash, ExtendedTransactionInfo>();
  public Dictionary<uint32_t, List<Crypto.Hash>> transactionHashesByBlocks = new Dictionary<uint32_t, List<Crypto.Hash>>();
  public Dictionary<uint32_t, CachedBlockInfo> cachedBlocks = new Dictionary<uint32_t, CachedBlockInfo>();
  public Dictionary<Crypto.Hash, uint32_t> blockIndexesByBlockHashes = new Dictionary<Crypto.Hash, uint32_t>();
  public Dictionary<uint64_t, uint32_t> keyOutputGlobalIndexesCountForAmounts = new Dictionary<uint64_t, uint32_t>();
  public Dictionary<Tuple<uint64_t, uint32_t>, PackedOutIndex> keyOutputGlobalIndexesForAmounts = new Dictionary<Tuple<uint64_t, uint32_t>, PackedOutIndex>();
  public Dictionary<uint32_t, RawBlock> rawBlocks = new Dictionary<uint32_t, RawBlock>();
  public Dictionary<uint64_t, uint32_t> closestTimestampBlockIndex = new Dictionary<uint64_t, uint32_t>();
  public Dictionary<uint32_t, uint64_t> keyOutputAmounts = new Dictionary<uint32_t, uint64_t>();
  public Dictionary<Crypto.Hash, uint32_t> transactionCountsByPaymentIds = new Dictionary<Crypto.Hash, uint32_t>();
  public Dictionary<Tuple<Crypto.Hash, uint32_t>, Crypto.Hash> transactionHashesByPaymentIds = new Dictionary<Tuple<Crypto.Hash, uint32_t>, Crypto.Hash>();
  public Dictionary<uint64_t, List<Crypto.Hash>> blockHashesByTimestamp = new Dictionary<uint64_t, List<Crypto.Hash>>();
  public KeyOutputKeyResult keyOutputKeys = new KeyOutputKeyResult();

  public Tuple<uint32_t, bool> lastBlockIndex = new Tuple<uint32_t, bool>(0, false);
  public Tuple<uint32_t, bool> keyOutputAmountsCount = new Tuple<uint32_t, bool>({}, false);
  public Tuple<uint64_t, bool> transactionsCount = new Tuple<uint64_t, bool>(0, false);

//C++ TO C# CONVERTER TODO TASK: C# has no equivalent to ' = default':
//  BlockchainReadState() = default;
//C++ TO C# CONVERTER TODO TASK: C# has no equivalent to ' = default':
//  BlockchainReadState(const BlockchainReadState&) = default;
//C++ TO C# CONVERTER TODO TASK: 'rvalue references' have no equivalent in C#:
  public BlockchainReadState(BlockchainReadState && state)
  {
	  this.spentKeyImagesByBlock = std::move(state.spentKeyImagesByBlock);
	  this.blockIndexesBySpentKeyImages = std::move(state.blockIndexesBySpentKeyImages);
	  this.cachedTransactions = std::move(state.cachedTransactions);
	  this.transactionHashesByBlocks = std::move(state.transactionHashesByBlocks);
	  this.cachedBlocks = std::move(state.cachedBlocks);
	  this.blockIndexesByBlockHashes = std::move(state.blockIndexesByBlockHashes);
	  this.keyOutputGlobalIndexesCountForAmounts = std::move(state.keyOutputGlobalIndexesCountForAmounts);
	  this.keyOutputGlobalIndexesForAmounts = std::move(state.keyOutputGlobalIndexesForAmounts);
	  this.rawBlocks = std::move(state.rawBlocks);
	  this.blockHashesByTimestamp = std::move(state.blockHashesByTimestamp);
	  this.keyOutputKeys = std::move(state.keyOutputKeys);
	  this.closestTimestampBlockIndex = std::move(state.closestTimestampBlockIndex);
	  this.lastBlockIndex = std::move(state.lastBlockIndex);
	  this.keyOutputAmountsCount = std::move(state.keyOutputAmountsCount);
	  this.keyOutputAmounts = std::move(state.keyOutputAmounts);
	  this.transactionCountsByPaymentIds = std::move(state.transactionCountsByPaymentIds);
	  this.transactionHashesByPaymentIds = std::move(state.transactionHashesByPaymentIds);
	  this.transactionsCount = std::move(state.transactionsCount);
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: size_t size() const
  public size_t size()
  {
	return spentKeyImagesByBlock.Count + blockIndexesBySpentKeyImages.Count + cachedTransactions.Count + transactionHashesByBlocks.Count + cachedBlocks.Count + blockIndexesByBlockHashes.Count + keyOutputGlobalIndexesCountForAmounts.Count + keyOutputGlobalIndexesForAmounts.Count + rawBlocks.Count + closestTimestampBlockIndex.Count + keyOutputAmounts.Count + transactionCountsByPaymentIds.Count + transactionHashesByPaymentIds.Count + blockHashesByTimestamp.Count + keyOutputKeys.size() + (lastBlockIndex.Item2 ? 1 : 0) + (keyOutputAmountsCount.Item2 ? 1 : 0) + (transactionsCount.Item2 ? 1 : 0);
  }
}

public class BlockchainReadResult : System.IDisposable
{
  public BlockchainReadResult(BlockchainReadState _state)
  {
	  this.state = new CryptoNote.BlockchainReadState(std::move(_state));

  }
  public void Dispose()
  {

  }

//C++ TO C# CONVERTER TODO TASK: 'rvalue references' have no equivalent in C#:
  public BlockchainReadResult(BlockchainReadResult && result)
  {
	  this.state = new CryptoNote.BlockchainReadState(std::move(result.state));
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint32_t, ClassicVector<Crypto::KeyImage>>& getSpentKeyImagesByBlock() const
  public Dictionary<uint32_t, List<Crypto.KeyImage>> getSpentKeyImagesByBlock()
  {
	return state.spentKeyImagesByBlock;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<Crypto::KeyImage, uint32_t>& getBlockIndexesBySpentKeyImages() const
  public Dictionary<Crypto.KeyImage, uint32_t> getBlockIndexesBySpentKeyImages()
  {
	return state.blockIndexesBySpentKeyImages;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<Crypto::Hash, ExtendedTransactionInfo>& getCachedTransactions() const
  public Dictionary<Crypto.Hash, ExtendedTransactionInfo> getCachedTransactions()
  {
	return state.cachedTransactions;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint32_t, ClassicVector<Crypto::Hash>>& getTransactionHashesByBlocks() const
  public Dictionary<uint32_t, List<Crypto.Hash>> getTransactionHashesByBlocks()
  {
	return state.transactionHashesByBlocks;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint32_t, CachedBlockInfo>& getCachedBlocks() const
  public Dictionary<uint32_t, CachedBlockInfo> getCachedBlocks()
  {
	return state.cachedBlocks;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<Crypto::Hash, uint32_t>& getBlockIndexesByBlockHashes() const
  public Dictionary<Crypto.Hash, uint32_t> getBlockIndexesByBlockHashes()
  {
	return state.blockIndexesByBlockHashes;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint64_t, uint32_t>& getKeyOutputGlobalIndexesCountForAmounts() const
  public Dictionary<uint64_t, uint32_t> getKeyOutputGlobalIndexesCountForAmounts()
  {
	return state.keyOutputGlobalIndexesCountForAmounts;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<System.Tuple<uint64_t, uint32_t>, PackedOutIndex>& getKeyOutputGlobalIndexesForAmounts() const
  public Dictionary<Tuple<uint64_t, uint32_t>, PackedOutIndex> getKeyOutputGlobalIndexesForAmounts()
  {
	return state.keyOutputGlobalIndexesForAmounts;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint32_t, RawBlock>& getRawBlocks() const
  public Dictionary<uint32_t, RawBlock> getRawBlocks()
  {
	return state.rawBlocks;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const System.Tuple<uint32_t, bool>& getLastBlockIndex() const
  public Tuple<uint32_t, bool> getLastBlockIndex()
  {
	return state.lastBlockIndex;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint64_t, uint32_t>& getClosestTimestampBlockIndex() const
  public Dictionary<uint64_t, uint32_t> getClosestTimestampBlockIndex()
  {
	return state.closestTimestampBlockIndex;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint32_t getKeyOutputAmountsCount() const
  public uint32_t getKeyOutputAmountsCount()
  {
	return state.keyOutputAmountsCount.Item1;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint32_t, uint64_t>& getKeyOutputAmounts() const
  public Dictionary<uint32_t, uint64_t> getKeyOutputAmounts()
  {
	return state.keyOutputAmounts;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<Crypto::Hash, uint32_t>& getTransactionCountByPaymentIds() const
  public Dictionary<Crypto.Hash, uint32_t> getTransactionCountByPaymentIds()
  {
	return state.transactionCountsByPaymentIds;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<System.Tuple<Crypto::Hash, uint32_t>, Crypto::Hash>& getTransactionHashesByPaymentIds() const
  public Dictionary<Tuple<Crypto.Hash, uint32_t>, Crypto.Hash> getTransactionHashesByPaymentIds()
  {
	return state.transactionHashesByPaymentIds;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ClassicUnorderedMap<uint64_t, ClassicVector<Crypto::Hash>>& getBlockHashesByTimestamp() const
  public Dictionary<uint64_t, List<Crypto.Hash>> getBlockHashesByTimestamp()
  {
	return state.blockHashesByTimestamp;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const System.Tuple<uint64_t, bool>& getTransactionsCount() const
  public Tuple<uint64_t, bool> getTransactionsCount()
  {
	return state.transactionsCount;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const KeyOutputKeyResult& getKeyOutputInfo() const
  public KeyOutputKeyResult getKeyOutputInfo()
  {
	return state.keyOutputKeys;
  }

  private BlockchainReadState state = new BlockchainReadState();
}

public class BlockchainReadBatch : IReadBatch, System.IDisposable
{
  public BlockchainReadBatch()
  {

  }
  public void Dispose()
  {

  }

  public BlockchainReadBatch requestSpentKeyImagesByBlock(uint32_t blockIndex)
  {
	state.spentKeyImagesByBlock.Add(blockIndex, new List<Crypto.KeyImage>());
	return this;
  }
  public BlockchainReadBatch requestBlockIndexBySpentKeyImage(Crypto.KeyImage keyImage)
  {
	state.blockIndexesBySpentKeyImages.Add(keyImage, 0);
	return this;
  }
  public BlockchainReadBatch requestCachedTransaction(Crypto.Hash txHash)
  {
	state.cachedTransactions.Add(txHash, new ExtendedTransactionInfo());
	return this;
  }
  public BlockchainReadBatch requestTransactionHashesByBlock(uint32_t blockIndex)
  {
	state.transactionHashesByBlocks.Add(blockIndex, new List<Crypto.Hash>());
	return this;
  }
  public BlockchainReadBatch requestCachedBlock(uint32_t blockIndex)
  {
	state.cachedBlocks.Add(blockIndex, new CachedBlockInfo());
	return this;
  }
  public BlockchainReadBatch requestBlockIndexByBlockHash(Crypto.Hash blockHash)
  {
	state.blockIndexesByBlockHashes.Add(blockHash, 0);
	return this;
  }
  public BlockchainReadBatch requestKeyOutputGlobalIndexesCountForAmount(uint64_t amount)
  {
	state.keyOutputGlobalIndexesCountForAmounts.Add(amount, 0);
	return this;
  }
  public BlockchainReadBatch requestKeyOutputGlobalIndexForAmount(uint64_t amount, uint32_t outputIndexWithinAmout)
  {
	state.keyOutputGlobalIndexesForAmounts.Add(Tuple.Create(amount, outputIndexWithinAmout), new PackedOutIndex());
	return this;
  }
  public BlockchainReadBatch requestRawBlock(uint32_t blockIndex)
  {
	state.rawBlocks.Add(blockIndex, new RawBlock());
	return this;
  }
  public BlockchainReadBatch requestLastBlockIndex()
  {
	state.lastBlockIndex.Item2 = true;
	return this;
  }
  public BlockchainReadBatch requestClosestTimestampBlockIndex(uint64_t timestamp)
  {
	state.closestTimestampBlockIndex[timestamp];
	return this;
  }
  public BlockchainReadBatch requestKeyOutputAmountsCount()
  {
	state.keyOutputAmountsCount.Item2 = true;
	return this;
  }
  public BlockchainReadBatch requestKeyOutputAmount(uint32_t index)
  {
	state.keyOutputAmounts.Add(index, 0);
	return this;
  }
  public BlockchainReadBatch requestTransactionCountByPaymentId(Crypto.Hash paymentId)
  {
	state.transactionCountsByPaymentIds.Add(paymentId, 0);
	return this;
  }
  public BlockchainReadBatch requestTransactionHashByPaymentId(Crypto.Hash paymentId, uint32_t transactionIndexWithinPaymentId)
  {
	state.transactionHashesByPaymentIds.Add(Tuple.Create(paymentId, transactionIndexWithinPaymentId), GlobalMembers.NULL_HASH);
	return this;
  }
  public BlockchainReadBatch requestBlockHashesByTimestamp(uint64_t timestamp)
  {
	state.blockHashesByTimestamp.Add(timestamp, new List<Crypto.Hash>());
	return this;
  }
  public BlockchainReadBatch requestTransactionsCount()
  {
	state.transactionsCount.Item2 = true;
	return this;
  }
  public BlockchainReadBatch requestKeyOutputInfo(uint64_t amount, uint32_t globalIndex)
  {
	state.keyOutputKeys.emplace(Tuple.Create(amount, globalIndex), new KeyOutputInfo({}));
	return this;
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ClassicVector<string> getRawKeys() const override
  public List<string> getRawKeys()
  {
	List<string> rawKeys = new List<string>();
	rawKeys.Capacity = state.size();

	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.BLOCK_INDEX_TO_KEY_IMAGE_PREFIX, state.spentKeyImagesByBlock);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.KEY_IMAGE_TO_BLOCK_INDEX_PREFIX, state.blockIndexesBySpentKeyImages);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.TRANSACTION_HASH_TO_TRANSACTION_INFO_PREFIX, state.cachedTransactions);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.BLOCK_INDEX_TO_TX_HASHES_PREFIX, state.transactionHashesByBlocks);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.BLOCK_INDEX_TO_BLOCK_INFO_PREFIX, state.cachedBlocks);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.BLOCK_HASH_TO_BLOCK_INDEX_PREFIX, state.blockIndexesByBlockHashes);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.KEY_OUTPUT_AMOUNT_PREFIX, state.keyOutputGlobalIndexesCountForAmounts);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.KEY_OUTPUT_AMOUNT_PREFIX, state.keyOutputGlobalIndexesForAmounts);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.BLOCK_INDEX_TO_RAW_BLOCK_PREFIX, state.rawBlocks);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.CLOSEST_TIMESTAMP_BLOCK_INDEX_PREFIX, state.closestTimestampBlockIndex);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.KEY_OUTPUT_AMOUNTS_COUNT_PREFIX, state.keyOutputAmounts);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.PAYMENT_ID_TO_TX_HASH_PREFIX, state.transactionCountsByPaymentIds);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.PAYMENT_ID_TO_TX_HASH_PREFIX, state.transactionHashesByPaymentIds);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.TIMESTAMP_TO_BLOCKHASHES_PREFIX, state.blockHashesByTimestamp);
	DB.GlobalMembers.serializeKeys(rawKeys, DB.GlobalMembers.KEY_OUTPUT_KEY_PREFIX, state.keyOutputKeys);

	if (state.lastBlockIndex.Item2)
	{
	  rawKeys.emplace_back(DB.GlobalMembers.serializeKey(DB.GlobalMembers.BLOCK_INDEX_TO_BLOCK_HASH_PREFIX, DB.GlobalMembers.LAST_BLOCK_INDEX_KEY));
	}

	if (state.keyOutputAmountsCount.Item2)
	{
	  rawKeys.emplace_back(DB.GlobalMembers.serializeKey(DB.GlobalMembers.KEY_OUTPUT_AMOUNTS_COUNT_PREFIX, DB.GlobalMembers.KEY_OUTPUT_AMOUNTS_COUNT_KEY));
	}

	if (state.transactionsCount.Item2)
	{
	  rawKeys.emplace_back(DB.GlobalMembers.serializeKey(DB.GlobalMembers.TRANSACTION_HASH_TO_TRANSACTION_INFO_PREFIX, DB.GlobalMembers.TRANSACTIONS_COUNT_KEY));
	}

	Debug.Assert(rawKeys.Count > 0);
	return rawKeys;
  }
  public void submitRawResult(List<string> values, List<bool> resultStates)
  {
	Debug.Assert(state.size() == values.Count);
	Debug.Assert(values.Count == resultStates.Count);
	var range = boost::combine(values, resultStates);
	var iter = range.begin();

	DB.GlobalMembers.deserializeValues(state.spentKeyImagesByBlock, iter, DB.GlobalMembers.BLOCK_INDEX_TO_KEY_IMAGE_PREFIX);
	DB.GlobalMembers.deserializeValues(state.blockIndexesBySpentKeyImages, iter, DB.GlobalMembers.KEY_IMAGE_TO_BLOCK_INDEX_PREFIX);
	DB.GlobalMembers.deserializeValues(state.cachedTransactions, iter, DB.GlobalMembers.TRANSACTION_HASH_TO_TRANSACTION_INFO_PREFIX);
	DB.GlobalMembers.deserializeValues(state.transactionHashesByBlocks, iter, DB.GlobalMembers.BLOCK_INDEX_TO_TX_HASHES_PREFIX);
	DB.GlobalMembers.deserializeValues(state.cachedBlocks, iter, DB.GlobalMembers.BLOCK_INDEX_TO_BLOCK_INFO_PREFIX);
	DB.GlobalMembers.deserializeValues(state.blockIndexesByBlockHashes, iter, DB.GlobalMembers.BLOCK_HASH_TO_BLOCK_INDEX_PREFIX);
	DB.GlobalMembers.deserializeValues(state.keyOutputGlobalIndexesCountForAmounts, iter, DB.GlobalMembers.KEY_OUTPUT_AMOUNT_PREFIX);
	DB.GlobalMembers.deserializeValues(state.keyOutputGlobalIndexesForAmounts, iter, DB.GlobalMembers.KEY_OUTPUT_AMOUNT_PREFIX);
	DB.GlobalMembers.deserializeValues(state.rawBlocks, iter, DB.GlobalMembers.BLOCK_INDEX_TO_RAW_BLOCK_PREFIX);
	DB.GlobalMembers.deserializeValues(state.closestTimestampBlockIndex, iter, DB.GlobalMembers.CLOSEST_TIMESTAMP_BLOCK_INDEX_PREFIX);
	DB.GlobalMembers.deserializeValues(state.keyOutputAmounts, iter, DB.GlobalMembers.KEY_OUTPUT_AMOUNTS_COUNT_PREFIX);
	DB.GlobalMembers.deserializeValues(state.transactionCountsByPaymentIds, iter, DB.GlobalMembers.PAYMENT_ID_TO_TX_HASH_PREFIX);
	DB.GlobalMembers.deserializeValues(state.transactionHashesByPaymentIds, iter, DB.GlobalMembers.PAYMENT_ID_TO_TX_HASH_PREFIX);
	DB.GlobalMembers.deserializeValues(state.blockHashesByTimestamp, iter, DB.GlobalMembers.TIMESTAMP_TO_BLOCKHASHES_PREFIX);
	DB.GlobalMembers.deserializeValues(state.keyOutputKeys, iter, DB.GlobalMembers.KEY_OUTPUT_KEY_PREFIX);

	DB.GlobalMembers.deserializeValue(ref state.lastBlockIndex, iter, DB.GlobalMembers.BLOCK_INDEX_TO_BLOCK_HASH_PREFIX);
	DB.GlobalMembers.deserializeValue(ref state.keyOutputAmountsCount, iter, DB.GlobalMembers.KEY_OUTPUT_AMOUNTS_COUNT_PREFIX);
	DB.GlobalMembers.deserializeValue(ref state.transactionsCount, iter, DB.GlobalMembers.TRANSACTION_HASH_TO_TRANSACTION_INFO_PREFIX);

	Debug.Assert(iter == range.end());

	resultSubmitted = true;
  }

  public BlockchainReadResult extractResult()
  {
	Debug.Assert(resultSubmitted);
	var st = std::move(state);
	state.lastBlockIndex = new Tuple<uint32_t, bool>(0, false);
	state.keyOutputAmountsCount = new Tuple<uint32_t, bool>({}, false);

	resultSubmitted = false;
	return new BlockchainReadResult(st);
  }

  private bool resultSubmitted = false;
  private BlockchainReadState state = new BlockchainReadState();
}

}