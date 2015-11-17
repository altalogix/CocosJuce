/*
  ==============================================================================

    CocosJuceMain.cpp
    Created: 23 Oct 2015 5:31:11pm
    Author:  Leo Olivers

  ==============================================================================
*/

#include "CocosJuceMain.h"


CocosJuceMain::Ptr CocosJuceMain::current_;


CocosJuceMain::CocosJuceMain() : isInitialised_(false), isSuspended_(false)
{

#if JUCE_IOS || JUCE_WINDOWS
	
	juce::initialiseJuce_GUI();

	// note: on Android this is being taken care of in a different way 
	// (i.e. by calling the launchApp() method on the generated java Juce Activity)

#endif

	audioDeviceManager_.addAudioCallback(&audioSourcePlayer_);
	
	juce::String result = audioDeviceManager_.initialiseWithDefaultDevices(0, 2);

	if (result.isNotEmpty())
	{
		juce::String error = "CocosJuceMain::ctor: could not initialise audioDeviceManager: ";
		error += result;
		juce::Logger::outputDebugString(error);
		return;
	}

	toneGeneratorAudioSource_.setFrequency(0);
	toneGeneratorAudioSource_.setAmplitude(0.0f);
	
	audioSourcePlayer_.setSource(&toneGeneratorAudioSource_);


	isInitialised_ = true;

	}

    
CocosJuceMain::~CocosJuceMain() 
{
	if (isInitialised_)
	{
		audioDeviceManager_.removeAudioCallback(&audioSourcePlayer_);

		audioSourcePlayer_.setSource(0);
	}

#if JUCE_IOS || JUCE_WINDOWS

	juce::shutdownJuce_GUI();

	// note: on Android this is being taken care of in a different way 
	// (i.e. by calling the quitApp() method on the generated java Juce Activity)

#endif

}


bool CocosJuceMain::startTestTone(double frequency, float amplitude)
{ 

	if (!isInitialised_)
	{
		return false;
	}

	toneGeneratorAudioSource_.setFrequency(frequency);

	toneGeneratorAudioSource_.setAmplitude(amplitude);

	return true;
}


bool CocosJuceMain::stopTestTone() 
{ 
	if (!isInitialised_)
	{
		return false;
	}

	toneGeneratorAudioSource_.setAmplitude(0.0f);

	return true;
}

bool CocosJuceMain::suspend()
{
	if (isInitialised_ && !isSuspended_)
	{
		audioDeviceManager_.removeAudioCallback(&audioSourcePlayer_);
		isSuspended_ = true;
		return true;
	}
	return false;
}

bool CocosJuceMain::resume()
{
	if (isSuspended_)
	{
		audioDeviceManager_.addAudioCallback(&audioSourcePlayer_);
		isSuspended_ = false;
		return true;
	}
	return false;
}
 
    
CocosJuceMain::Ptr CocosJuceMain::current()
{
	if (!current_)
	{
		current_ = new CocosJuceMain;
	}
	return current_;
}

void CocosJuceMain::release()
{
	current_ = 0;

}

