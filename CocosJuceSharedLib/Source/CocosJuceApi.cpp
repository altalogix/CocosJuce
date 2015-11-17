/*
  ==============================================================================

    CocosJuceApi.cpp
    Created: 23 Oct 2015 5:23:30pm
    Author:  Leo Olivers

  ==============================================================================
*/

#include "CocosJuceApi.h"
#include "CocosJuceMain.h"


EXPORT_BOOL cocosjuce_start_test_tone(double frequency, float amplitude)
{
    return CocosJuceMain::current()->startTestTone(frequency, amplitude);
}

    
EXPORT_BOOL cocosjuce_stop_test_tone()
{
    return CocosJuceMain::current()->stopTestTone();
}


EXPORT_BOOL cocosjuce_suspend()
{
	return CocosJuceMain::current()->suspend();
}


EXPORT_BOOL cocosjuce_resume()
{
	return CocosJuceMain::current()->resume();
}


EXPORT_VOID cocosjuce_release()
{
	return CocosJuceMain::release();
}
