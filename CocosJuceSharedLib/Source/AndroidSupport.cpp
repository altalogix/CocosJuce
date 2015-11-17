/*
  ==============================================================================

    AndroidSupport.cpp
    Created: 23 Oct 2015 5:46:53pm
    Author:  Leo Olivers

  ==============================================================================
*/

#if JUCE_ANDROID

#include "platform.h"


	class CocosJuceApp : public juce::JUCEApplication
	{
	
	  public:
	
	    CocosJuceApp() {}
	    
	    ~CocosJuceApp() {}

		void initialise(const juce::String& commandLine) override {}
	
		void shutdown() override {}

		void suspended() override {}

		void resumed() override {}
		
		void systemRequestedQuit() override	{ quit();	}
	
		const juce::String getApplicationName() override { return "CocosJuce";	}
	
		const juce::String getApplicationVersion() override	{ return "1.0";	}
	};
	
	

	START_JUCE_APPLICATION(CocosJuceApp)


#endif
