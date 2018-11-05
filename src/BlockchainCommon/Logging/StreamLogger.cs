﻿// Copyright (c) 2012-2017, The CryptoNote developers, The Bytecoin developers
//
// Please see the included LICENSE.txt file for more information.


//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define ENDL std::endl

namespace Logging
{

public class StreamLogger : CommonLogger
{
  public StreamLogger(Level level = DEBUGGING) : base.functorMethod(level)
  {
	  this.stream = null;
  }
  public StreamLogger(std::ostream stream, Level level = DEBUGGING) : base.functorMethod(level)
  {
	  this.stream = stream;
  }
  public void attachToStream(std::ostream stream)
  {
	this.stream = stream;
  }

  protected override void doLogString(string message)
  {
	if (stream != null && stream.good())
	{
	  lock (mutex)
	  {
		  bool readingText = true;
	  }
	  for (uint charPos = 0; charPos < message.Length; ++charPos)
	  {
		if (message[charPos] == base.COLOR_DELIMETER)
		{
		  readingText = !readingText;
		}
		else if (readingText)
		{
		  stream << message[charPos];
		}
	  }

	  stream << std::flush;
	}
  }

  protected std::ostream stream;

  private object mutex = new object();
}

}


