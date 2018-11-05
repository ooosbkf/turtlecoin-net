﻿// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
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
//ORIGINAL LINE: #define KV_MEMBER(member) s(member, #member);

using Crypto;
using System.Collections.Generic;

namespace CryptoNote
{

public class TransactionPrefixImpl : ITransactionReader
{
  public TransactionPrefixImpl()
  {
  }
  public TransactionPrefixImpl(TransactionPrefix prefix, Hash transactionHash)
  {
	m_extra.parse(prefix.extra);

//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: m_txPrefix = prefix;
	m_txPrefix.CopyFrom(prefix);
	m_txHash = transactionHash;
  }

  public override void Dispose()
  {
	  base.Dispose();
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual Hash getTransactionHash() const override
  public override Hash getTransactionHash()
  {
	return m_txHash;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual Hash getTransactionPrefixHash() const override
  public override Hash getTransactionPrefixHash()
  {
	return CryptoNote.GlobalMembers.getObjectHash(m_txPrefix);
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual PublicKey getTransactionPublicKey() const override
  public override PublicKey getTransactionPublicKey()
  {
	Crypto.PublicKey pk = new Crypto.PublicKey(GlobalMembers.NULL_PUBLIC_KEY);
	m_extra.getPublicKey(ref pk);
	return pk;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual uint64_t getUnlockTime() const override
  public override uint64_t getUnlockTime()
  {
	return m_txPrefix.unlockTime;
  }

  // extra
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool getPaymentId(Hash& hash) const override
  public override bool getPaymentId(ref Hash hash)
  {
	List<uint8_t> nonce = new List<uint8_t>();

	if (getExtraNonce(nonce))
	{
	  Crypto.Hash paymentId = new Crypto.Hash();
	  if (getPaymentIdFromTransactionExtraNonce(nonce, paymentId))
	  {
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to 'reinterpret_cast' in C#:
		hash = reinterpret_cast<const Hash&>(paymentId);
		return true;
	  }
	}

	return false;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool getExtraNonce(BinaryArray& nonce) const override;
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//  override bool getExtraNonce(BinaryArray nonce);
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ClassicVector<uint8_t> getExtra() const override
  public override List<uint8_t> getExtra()
  {
	return m_txPrefix.extra;
  }

  // inputs
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual size_t getInputCount() const override
  public override size_t getInputCount()
  {
	return m_txPrefix.inputs.Count;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual uint64_t getInputTotalAmount() const override
  public override uint64_t getInputTotalAmount()
  {
	return std::accumulate(m_txPrefix.inputs.GetEnumerator(), m_txPrefix.inputs.end(), 0UL, (uint64_t val, boost::variant<BaseInput, KeyInput> in) =>
	{
	  return val + getTransactionInputAmount(in);
	});
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual TransactionTypes::InputType getInputType(size_t index) const override
  public override TransactionTypes.InputType getInputType(size_t index)
  {
	return getTransactionInputType(getInputChecked(m_txPrefix, index));
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void getInput(size_t index, KeyInput& input) const override
  public override void getInput(size_t index, ref KeyInput input)
  {
	input = boost::get<KeyInput>(getInputChecked(m_txPrefix, index, TransactionTypes.InputType.Key));
  }

  // outputs
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual size_t getOutputCount() const override
  public override size_t getOutputCount()
  {
	return m_txPrefix.outputs.Count;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual uint64_t getOutputTotalAmount() const override
  public override uint64_t getOutputTotalAmount()
  {
	return std::accumulate(m_txPrefix.outputs.GetEnumerator(), m_txPrefix.outputs.end(), 0UL, (uint64_t val, TransactionOutput @out) =>
	{
	  return val + @out.amount;
	});
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual TransactionTypes::OutputType getOutputType(size_t index) const override
  public override TransactionTypes.OutputType getOutputType(size_t index)
  {
	return getTransactionOutputType(getOutputChecked(m_txPrefix, index).target);
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void getOutput(size_t index, KeyOutput& output, uint64_t& amount) const override
  public override void getOutput(size_t index, ref KeyOutput output, ref uint64_t amount)
  {
	auto @out = getOutputChecked(m_txPrefix, index, TransactionTypes.OutputType.Key);
	output = boost::get<KeyOutput>(@out.target);
	amount = @out.amount;
  }

  // signatures
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual size_t getRequiredSignaturesCount(size_t inputIndex) const override
  public override size_t getRequiredSignaturesCount(size_t inputIndex)
  {
	return global::CryptoNote.getRequiredSignaturesCount(getInputChecked(m_txPrefix, inputIndex));
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool findOutputsToAccount(const AccountPublicAddress& addr, const SecretKey& viewSecretKey, ClassicVector<uint32_t>& outs, uint64_t& outputAmount) const override
  public override bool findOutputsToAccount(AccountPublicAddress addr, SecretKey viewSecretKey, List<uint32_t> outs, uint64_t outputAmount)
  {
	return global::CryptoNote.findOutputsToAccount(m_txPrefix, addr, viewSecretKey, outs, outputAmount);
  }

  // various checks
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool validateInputs() const override
  public override bool validateInputs()
  {
	return checkInputTypesSupported(m_txPrefix) && checkInputsOverflow(m_txPrefix) && checkInputsKeyimagesDiff(m_txPrefix);
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool validateOutputs() const override
  public override bool validateOutputs()
  {
	return checkOutsValid(m_txPrefix) && checkOutsOverflow(m_txPrefix);
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool validateSignatures() const override
  public override bool validateSignatures()
  {
	throw std::system_error(std::make_error_code(std::errc.function_not_supported), "Validating signatures is not supported for transaction prefix");
  }

  // serialized transaction
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ClassicVector<uint8_t> getTransactionData() const override
  public override List<uint8_t> getTransactionData()
  {
	return CryptoNote.GlobalMembers.toBinaryArray(m_txPrefix);
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual bool getTransactionSecretKey(SecretKey& key) const override
  public override bool getTransactionSecretKey(SecretKey key)
  {
	return false;
  }

  private TransactionPrefix m_txPrefix = new TransactionPrefix();
  private TransactionExtra m_extra = new TransactionExtra();
  private Hash m_txHash = new Hash();
}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool TransactionPrefixImpl::getExtraNonce(ClassicVector<uint8_t>& nonce) const

}