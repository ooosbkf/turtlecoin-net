﻿// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
//
// Please see the included LICENSE.txt file for more information.


namespace CryptoNote
{

public class P2pNodeConfig : NetNodeConfig
{
  public P2pNodeConfig()
  {
	  this.timedSyncInterval = std::chrono.seconds(P2P_DEFAULT_HANDSHAKE_INTERVAL);
	  this.handshakeTimeout = std::chrono.milliseconds(P2P_DEFAULT_HANDSHAKE_INVOKE_TIMEOUT);
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.connectInterval = P2P_DEFAULT_CONNECT_INTERVAL;
	  this.connectInterval.CopyFrom(GlobalMembers.P2P_DEFAULT_CONNECT_INTERVAL);
	  this.connectTimeout = std::chrono.milliseconds(P2P_DEFAULT_CONNECTION_TIMEOUT);
	  this.networkId = CryptoNote.CRYPTONOTE_NETWORK;
	  this.expectedOutgoingConnectionsCount = P2P_DEFAULT_CONNECTIONS_COUNT;
	  this.whiteListConnectionsPercent = P2P_DEFAULT_WHITELIST_CONNECTIONS_PERCENT;
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.peerListConnectRange = P2P_DEFAULT_CONNECT_RANGE;
	  this.peerListConnectRange.CopyFrom(GlobalMembers.P2P_DEFAULT_CONNECT_RANGE);
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.peerListGetTryCount = P2P_DEFAULT_PEERLIST_GET_TRY_COUNT;
	  this.peerListGetTryCount.CopyFrom(GlobalMembers.P2P_DEFAULT_PEERLIST_GET_TRY_COUNT);
  }

  // getters

  // getters

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: std::chrono::nanoseconds getTimedSyncInterval() const
  public std::chrono.nanoseconds getTimedSyncInterval()
  {
	return timedSyncInterval;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: std::chrono::nanoseconds getHandshakeTimeout() const
  public std::chrono.nanoseconds getHandshakeTimeout()
  {
	return handshakeTimeout;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: std::chrono::nanoseconds getConnectInterval() const
  public std::chrono.nanoseconds getConnectInterval()
  {
	return connectInterval;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: std::chrono::nanoseconds getConnectTimeout() const
  public std::chrono.nanoseconds getConnectTimeout()
  {
	return connectTimeout;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint getExpectedOutgoingConnectionsCount() const
  public uint getExpectedOutgoingConnectionsCount()
  {
	return expectedOutgoingConnectionsCount;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint getWhiteListConnectionsPercent() const
  public uint getWhiteListConnectionsPercent()
  {
	return whiteListConnectionsPercent;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: boost::uuids::uuid getNetworkId() const
  public boost::uuids.uuid getNetworkId()
  {
	if (getTestnet())
	{
	  boost::uuids.uuid copy = networkId;
	  copy.data[0] += 1;
	  return copy;
	}
	return networkId;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint getPeerListConnectRange() const
  public uint getPeerListConnectRange()
  {
	return peerListConnectRange;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint getPeerListGetTryCount() const
  public uint getPeerListGetTryCount()
  {
	return peerListGetTryCount;
  }

  // setters

  // setters

  public void setTimedSyncInterval(std::chrono.nanoseconds interval)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: timedSyncInterval = interval;
	timedSyncInterval.CopyFrom(interval);
  }
  public void setHandshakeTimeout(std::chrono.nanoseconds timeout)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: handshakeTimeout = timeout;
	handshakeTimeout.CopyFrom(timeout);
  }
  public void setConnectInterval(std::chrono.nanoseconds interval)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: connectInterval = interval;
	connectInterval.CopyFrom(interval);
  }
  public void setConnectTimeout(std::chrono.nanoseconds timeout)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: connectTimeout = timeout;
	connectTimeout.CopyFrom(timeout);
  }
  public void setExpectedOutgoingConnectionsCount(uint count)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: expectedOutgoingConnectionsCount = count;
	expectedOutgoingConnectionsCount.CopyFrom(count);
  }
  public void setWhiteListConnectionsPercent(uint percent)
  {
	if (percent > 100)
	{
	  throw new System.ArgumentException("whiteListConnectionsPercent cannot be greater than 100");
	}

//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: whiteListConnectionsPercent = percent;
	whiteListConnectionsPercent.CopyFrom(percent);
  }
  public void setNetworkId(boost::uuids.uuid id)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: networkId = id;
	networkId.CopyFrom(id);
  }
  public void setPeerListConnectRange(uint range)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: peerListConnectRange = range;
	peerListConnectRange.CopyFrom(range);
  }
  public void setPeerListGetTryCount(uint count)
  {
//C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: peerListGetTryCount = count;
	peerListGetTryCount.CopyFrom(count);
  }

  private std::chrono.nanoseconds timedSyncInterval = new std::chrono.nanoseconds();
  private std::chrono.nanoseconds handshakeTimeout = new std::chrono.nanoseconds();
  private std::chrono.nanoseconds connectInterval = new std::chrono.nanoseconds();
  private std::chrono.nanoseconds connectTimeout = new std::chrono.nanoseconds();
  private boost::uuids.uuid networkId = new boost::uuids.uuid();
  private uint expectedOutgoingConnectionsCount = new uint();
  private uint whiteListConnectionsPercent = new uint();
  private uint peerListConnectRange = new uint();
  private uint peerListGetTryCount = new uint();
}

}



namespace CryptoNote
{

//C++ TO C# CONVERTER NOTE: C# does not allow anonymous namespaces:
//namespace


}
