﻿// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
//
// Please see the included LICENSE.txt file for more information.


using Common;
using System.Collections.Generic;
using System.Diagnostics;

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define KV_MEMBER(member) s(member, #member);

namespace CryptoNote
{

public class BinaryInputStreamSerializer : ISerializer
{
  public BinaryInputStreamSerializer(Common.IInputStream strm)
  {
	  this.stream = strm;
  }
  public override void Dispose()
  {
	  base.Dispose();
  }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ISerializer::SerializerType type() const override
  public override ISerializer.SerializerType type()
  {
	return ISerializer.INPUT;
  }

  public override bool BeginObject(Common.StringView name)
  {
	return true;
  }
  public override void EndObject()
  {
  }

  public override bool beginArray(ulong size, Common.StringView name)
  {
	GlobalMembers.readVarintAs<ulong>(stream, ref size);
	return true;
  }
  public override void EndArray()
  {
  }

  public static override bool functorMethod(ushort value, Common.StringView name)
  {
	readVarint(stream, value);
	return true;
  }
  public static override bool functorMethod(short value, Common.StringView name)
  {
	GlobalMembers.readVarintAs<ushort>(stream, ref value);
	return true;
  }
  public static override bool functorMethod(ushort value, Common.StringView name)
  {
	readVarint(stream, value);
	return true;
  }
  public static override bool functorMethod(int value, Common.StringView name)
  {
	GlobalMembers.readVarintAs<uint>(stream, ref value);
	return true;
  }
  public static override bool functorMethod(uint value, Common.StringView name)
  {
	readVarint(stream, value);
	return true;
  }
  public static override bool functorMethod(long value, Common.StringView name)
  {
	GlobalMembers.readVarintAs<ulong>(stream, ref value);
	return true;
  }
  public static override bool functorMethod(ulong value, Common.StringView name)
  {
	readVarint(stream, value);
	return true;
  }
  public static override bool functorMethod(ref double value, Common.StringView name)
  {
	Debug.Assert(false); //the method is not supported for this type of serialization
	throw new System.Exception("double serialization is not supported in BinaryInputStreamSerializer");
	return false;
  }
  public static override bool functorMethod(ref bool value, Common.StringView name)
  {
	value = read<ushort>(stream) != 0;
	return true;
  }
  public static override bool functorMethod(string value, Common.StringView name)
  {
	ulong size = new ulong();
	readVarint(stream, size);

	/* Can't take up more than a block size */
	if (size > CryptoNote.parameters.MAX_EXTRA_SIZE && (string)name.getData() == "mm_tag")
	{
	  List<char> temp = new List<char>();
	  temp.Resize(1);

	  /* Read to the end of the stream, and throw the data away, otherwise
	     transaction won't validate. There should be a better way to do this? */
	  while (size > 0)
	  {
		  checkedRead(ref temp[0], 1);
		  size--;
	  }

	  value = "";
	  return true;
	}

	if (size > 0)
	{
	  List<char> temp = new List<char>();
	  temp.Resize(size);
	  checkedRead(ref temp[0], new ulong(size));
	  value.reserve(size);
	  value.assign(temp[0], size);
	}
	else
	{
	  value = "";
	}

	return true;
  }
  public override bool Binary(object value, ulong size, Common.StringView name)
  {
	checkedRead(ref (char)value, new ulong(size));
	return true;
  }
  public override bool Binary(string value, Common.StringView name)
  {
	return this.functorMethod(value, name);
  }

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename T>
  public static new bool functorMethod<T>(T value, Common.StringView name)
  {
	return base  .FunctorMethod(value, name);
  }


  private void checkedRead(ref string buf, ulong size)
  {
	read(stream, buf, size);
  }
  private Common.IInputStream stream;
}

}

namespace CryptoNote
{

//C++ TO C# CONVERTER NOTE: C# does not allow anonymous namespaces:
//namespace

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename StorageType, typename T>


}
