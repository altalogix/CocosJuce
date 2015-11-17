/*
  ==============================================================================

    CocosJuceApi.h
    Created: 23 Oct 2015 5:19:33pm
    Author:  Leo Olivers

  ==============================================================================
*/

#ifndef COCOSJUCEAPI_H_INCLUDED
#define COCOSJUCEAPI_H_INCLUDED

#include "platform.h"


// C interface for non-C++ library consumers

extern "C"
{

	EXPORT_BOOL cocosjuce_start_test_tone(double frequency, float amplitude);
    
    EXPORT_BOOL cocosjuce_stop_test_tone();

	EXPORT_BOOL cocosjuce_suspend();

	EXPORT_BOOL cocosjuce_resume();

	EXPORT_VOID cocosjuce_release();

}


#endif  // COCOSJUCEAPI_H_INCLUDED
