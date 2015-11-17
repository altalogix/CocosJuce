/*
  ==============================================================================

    CocosJuceMain.h
    Created: 23 Oct 2015 5:31:11pm
    Author:  Leo Olivers

  ==============================================================================
*/

#ifndef COCOSJUCEMAIN_H_INCLUDED
#define COCOSJUCEMAIN_H_INCLUDED

#include "platform.h"

class CocosJuceMain : public juce::ReferenceCountedObject
{
  public:

    CocosJuceMain();
    
    virtual ~CocosJuceMain();


	bool startTestTone(double frequency, float amplitude);
    
    bool stopTestTone();

	bool suspend();

	bool resume();


	typedef juce::ReferenceCountedObjectPtr<CocosJuceMain> Ptr;

	static Ptr current();

	static void release();

  private:
  
	 static Ptr current_;

	 juce::AudioDeviceManager audioDeviceManager_;

	 juce::AudioSourcePlayer audioSourcePlayer_;

	 juce::ToneGeneratorAudioSource toneGeneratorAudioSource_;

	 bool isInitialised_;
	 bool isSuspended_;

};


#endif  // COCOSJUCEMAIN_H_INCLUDED
