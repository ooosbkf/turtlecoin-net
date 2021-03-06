﻿// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
//
// Please see the included LICENSE.txt file for more information.


using System.Diagnostics;

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CRYPTO_MAKE_COMPARABLE(type) namespace Crypto { inline bool operator==(const type &_v1, const type &_v2) { return std::memcmp(&_v1, &_v2, sizeof(type)) == 0; } inline bool operator!=(const type &_v1, const type &_v2) { return std::memcmp(&_v1, &_v2, sizeof(type)) != 0; } }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CRYPTO_MAKE_HASHABLE(type) CRYPTO_MAKE_COMPARABLE(type) namespace Crypto { static_assert(sizeof(uint) <= sizeof(type), "Size of " #type " must be at least that of uint"); inline uint hash_value(const type &_v) { return reinterpret_cast<const uint &>(_v); } } namespace std { template<> struct hash<Crypto::type> { uint operator()(const Crypto::type &_v) const { return reinterpret_cast<const uint &>(_v); } }; }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CN_SOFT_SHELL_ITER (CN_SOFT_SHELL_MEMORY / 2)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CN_SOFT_SHELL_PAD_MULTIPLIER (CN_SOFT_SHELL_WINDOW / CN_SOFT_SHELL_MULTIPLIER)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define CN_SOFT_SHELL_ITER_MULTIPLIER (CN_SOFT_SHELL_PAD_MULTIPLIER / 2)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define KV_MEMBER(member) s(member, #member);
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define ENDL std::endl

namespace CryptoNote
{
  public class UpgradeDetectorBase
  {
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	enum :
//C++ TO C# CONVERTER TODO TASK: The following method format was not recognized, possibly due to an unrecognized macro:
	uint
	{
	  UNDEF_HEIGHT = (uint) - 1,
	}
  }

//C++ TO C# CONVERTER TODO TASK: There is no equivalent in C# to 'static_assert':
//  static_assert(CryptoNote::UpgradeDetectorBase::UNDEF_HEIGHT == UINT32_C(0xFFFFFFFF), "UpgradeDetectorBase::UNDEF_HEIGHT has invalid value");

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename BC>
  public class BasicUpgradeDetector <BC>: UpgradeDetectorBase
  {
	public BasicUpgradeDetector(Currency currency, BC blockchain, ushort targetVersion, Logging.ILogger log)
	{
//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
		this.m_currency = new CryptoNote.Currency(currency);
		this.m_blockchain = blockchain;
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.m_targetVersion = targetVersion;
		this.m_targetVersion.CopyFrom(targetVersion);
		this.m_votingCompleteHeight = UNDEF_HEIGHT;
		this.logger = new Logging.LoggerRef(log, "upgrade");
	}

	public bool init()
	{
	  uint upgradeHeight = m_currency.upgradeHeight(new ushort(m_targetVersion));
	  if (upgradeHeight == UNDEF_HEIGHT)
	  {
		if (m_blockchain.empty())
		{
		  m_votingCompleteHeight = UNDEF_HEIGHT;

		}
		else if (m_targetVersion - 1 == m_blockchain.back().bl.majorVersion)
		{
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: m_votingCompleteHeight = findVotingCompleteHeight(static_cast<uint>(m_blockchain.size() - 1));
		  m_votingCompleteHeight.CopyFrom(findVotingCompleteHeight((uint)(m_blockchain.size() - 1)));

		}
		else if (m_targetVersion <= m_blockchain.back().bl.majorVersion)
		{
//C++ TO C# CONVERTER TODO TASK: Lambda expressions cannot be assigned to 'var':
		  var it = std::lower_bound(m_blockchain.begin(), m_blockchain.end(), m_targetVersion, (BC.value_type b, ushort v) =>
		  {
			  return b.bl.majorVersion < v;
		  });
		  if (it == m_blockchain.end() || it.bl.majorVersion != m_targetVersion)
		  {
			logger.functorMethod(Logging.Level.ERROR, Logging.BRIGHT_RED) << "Internal error: upgrade height isn't found";
			return false;
		  }

		  uint upgradeHeight = (uint)(it - m_blockchain.begin());
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: m_votingCompleteHeight = findVotingCompleteHeight(upgradeHeight);
		  m_votingCompleteHeight.CopyFrom(findVotingCompleteHeight(new uint(upgradeHeight)));
		  if (m_votingCompleteHeight == UNDEF_HEIGHT)
		  {
			logger.functorMethod(Logging.Level.ERROR, Logging.BRIGHT_RED) << "Internal error: voting complete height isn't found, upgrade height = " << upgradeHeight;
			return false;
		  }
		}
		else
		{
		  m_votingCompleteHeight = UNDEF_HEIGHT;
		}
	  }
	  else if (!m_blockchain.empty())
	  {
		if (m_blockchain.size() <= upgradeHeight + 1)
		{
		  if (m_blockchain.back().bl.majorVersion >= m_targetVersion)
		  {
			logger.functorMethod(Logging.Level.ERROR, Logging.BRIGHT_RED) << "Internal error: block at height " << (m_blockchain.size() - 1) << " has invalid version " << (int)(m_blockchain.back().bl.majorVersion) << ", expected " << (int)(m_targetVersion - 1) << " or less";
			return false;
		  }
		}
		else
		{
		  int blockVersionAtUpgradeHeight = m_blockchain[upgradeHeight].bl.majorVersion;
		  if (blockVersionAtUpgradeHeight != m_targetVersion - 1)
		  {
			logger.functorMethod(Logging.Level.ERROR, Logging.BRIGHT_RED) << "Internal error: block at height " << upgradeHeight << " has invalid version " << blockVersionAtUpgradeHeight << ", expected " << (int)(m_targetVersion - 1);
			return false;
		  }

		  int blockVersionAfterUpgradeHeight = m_blockchain[upgradeHeight + 1].bl.majorVersion;
		  if (blockVersionAfterUpgradeHeight != m_targetVersion)
		  {
			logger.functorMethod(Logging.Level.ERROR, Logging.BRIGHT_RED) << "Internal error: block at height " << (upgradeHeight + 1) << " has invalid version " << blockVersionAfterUpgradeHeight << ", expected " << (int)m_targetVersion;
			return false;
		  }
		}
	  }

	  return true;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ushort targetVersion() const
	public ushort targetVersion()
	{
		return m_targetVersion;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint votingCompleteHeight() const
	public uint votingCompleteHeight()
	{
		return m_votingCompleteHeight;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint upgradeHeight() const
	public uint upgradeHeight()
	{
	  if (m_currency.upgradeHeight(new ushort(m_targetVersion)) == UNDEF_HEIGHT)
	  {
		return m_votingCompleteHeight == UNDEF_HEIGHT ? UNDEF_HEIGHT : m_currency.calculateUpgradeHeight(new uint(m_votingCompleteHeight));
	  }
	  else
	  {
		return m_currency.upgradeHeight(new ushort(m_targetVersion));
	  }
	}

	public void blockPushed()
	{
	  Debug.Assert(!m_blockchain.empty());

	  if (m_currency.upgradeHeight(new ushort(m_targetVersion)) != UNDEF_HEIGHT)
	  {
		if (m_blockchain.size() <= m_currency.upgradeHeight(new ushort(m_targetVersion)) + 1)
		{
		  Debug.Assert(m_blockchain.back().bl.majorVersion <= m_targetVersion - 1);
		}
		else
		{
		  Debug.Assert(m_blockchain.back().bl.majorVersion >= m_targetVersion);
		}

	  }
	  else if (m_votingCompleteHeight != UNDEF_HEIGHT)
	  {
		Debug.Assert(m_blockchain.size() > m_votingCompleteHeight);

		if (m_blockchain.size() <= upgradeHeight())
		{
		  Debug.Assert(m_blockchain.back().bl.majorVersion == m_targetVersion - 1);

		  if (m_blockchain.size() % (60 * 60 / m_currency.difficultyTarget()) == 0)
		  {
			var interval = m_currency.difficultyTarget() * (upgradeHeight() - m_blockchain.size() + 2);
			DateTime upgradeTimestamp = time(null) + (DateTime)interval;
			tm upgradeTime = localtime(upgradeTimestamp);
			string upgradeTimeStr = new string(new char[40]);
			strftime(upgradeTimeStr, 40, "%H:%M:%S %Y.%m.%d", upgradeTime);
			CryptoNote.CachedBlock cachedBlock = new CryptoNote.CachedBlock(m_blockchain.back().bl);

			logger.functorMethod(Logging.Level.TRACE, Logging.BRIGHT_GREEN) << "###### UPGRADE is going to happen after block index " << upgradeHeight() << " at about " << upgradeTimeStr << " (in " << Common.timeIntervalToString(interval) << ")! Current last block index " << (m_blockchain.size() - 1) << ", hash " << cachedBlock.getBlockHash();
		  }
		}
		else if (m_blockchain.size() == upgradeHeight() + 1)
		{
		  Debug.Assert(m_blockchain.back().bl.majorVersion == m_targetVersion - 1);

		  logger.functorMethod(Logging.Level.TRACE, Logging.BRIGHT_GREEN) << "###### UPGRADE has happened! Starting from block index " << (upgradeHeight() + 1) << " blocks with major version below " << (int)m_targetVersion << " will be rejected!";
		}
		else
		{
		  Debug.Assert(m_blockchain.back().bl.majorVersion == m_targetVersion);
		}

	  }
	  else
	  {
		uint lastBlockHeight = (uint)(m_blockchain.size() - 1);
		if (isVotingComplete(new uint(lastBlockHeight)))
		{
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: m_votingCompleteHeight = lastBlockHeight;
		  m_votingCompleteHeight.CopyFrom(lastBlockHeight);
		  logger.functorMethod(Logging.Level.TRACE, Logging.BRIGHT_GREEN) << "###### UPGRADE voting complete at block index " << m_votingCompleteHeight << "! UPGRADE is going to happen after block index " << upgradeHeight() << "!";
		}
	  }
	}

	public void blockPopped()
	{
	  if (m_votingCompleteHeight != UNDEF_HEIGHT)
	  {
		Debug.Assert(m_currency.upgradeHeight(new ushort(m_targetVersion)) == UNDEF_HEIGHT);

		if (m_blockchain.size() == m_votingCompleteHeight)
		{
		  logger.functorMethod(Logging.Level.TRACE, Logging.BRIGHT_YELLOW) << "###### UPGRADE after block index " << upgradeHeight() << " has been canceled!";
		  m_votingCompleteHeight = UNDEF_HEIGHT;
		}
		else
		{
		  Debug.Assert(m_blockchain.size() > m_votingCompleteHeight);
		}
	  }
	}

	public uint getNumberOfVotes(uint height)
	{
	  if (height < m_currency.upgradeVotingWindow() - 1)
	  {
		return 0;
	  }

	  uint voteCounter = 0;
	  for (uint i = height + 1 - m_currency.upgradeVotingWindow(); i <= height; ++i)
	  {
		auto b = m_blockchain[i].bl;
		voteCounter += (b.majorVersion == m_targetVersion - 1) && (b.minorVersion == BLOCK_MINOR_VERSION_1) ? 1 : 0;
	  }

	  return voteCounter;
	}

	private uint findVotingCompleteHeight(uint probableUpgradeHeight)
	{
	  Debug.Assert(m_currency.upgradeHeight(new ushort(m_targetVersion)) == UNDEF_HEIGHT);

	  uint probableVotingCompleteHeight = probableUpgradeHeight > m_currency.maxUpgradeDistance() != null ? probableUpgradeHeight - m_currency.maxUpgradeDistance() : 0;
	  for (uint i = probableVotingCompleteHeight; i <= probableUpgradeHeight; ++i)
	  {
		if (isVotingComplete(new uint(i)))
		{
		  return i;
		}
	  }

	  return UNDEF_HEIGHT;
	}

	private bool isVotingComplete(uint height)
	{
	  Debug.Assert(m_currency.upgradeHeight(new ushort(m_targetVersion)) == UNDEF_HEIGHT);
	  Debug.Assert(m_currency.upgradeVotingWindow() > 1);
	  Debug.Assert(m_currency.upgradeVotingThreshold() > 0 && m_currency.upgradeVotingThreshold() <= 100);

	  uint voteCounter = getNumberOfVotes(new uint(height));
	  return m_currency.upgradeVotingThreshold() * m_currency.upgradeVotingWindow() <= 100 * voteCounter;
	}

	private Logging.LoggerRef logger = new Logging.LoggerRef();
	private readonly Currency m_currency;
	private BC m_blockchain;
	private ushort m_targetVersion = new ushort();
	private uint m_votingCompleteHeight = new uint();
  }
}


namespace CryptoNote
{

public class SimpleUpgradeDetector : IUpgradeDetector
{
  public SimpleUpgradeDetector(ushort targetVersion, uint upgradeIndex)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.m_targetVersion = targetVersion;
	  this.m_targetVersion.CopyFrom(targetVersion);
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.m_upgradeIndex = upgradeIndex;
	  this.m_upgradeIndex.CopyFrom(upgradeIndex);
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ushort targetVersion() const override
  public override ushort targetVersion()
  {
	return m_targetVersion;
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint upgradeIndex() const override
  public override uint upgradeIndex()
  {
	return m_upgradeIndex;
  }

  public new void Dispose()
  {
	  base.Dispose();
  }

  private ushort m_targetVersion = new ushort();
  private uint m_upgradeIndex = new uint();
}

}
