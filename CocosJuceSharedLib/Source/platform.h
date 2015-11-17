/*
  ==============================================================================

    platform.h
    Created: 23 Oct 2015 5:08:43pm
    Author:  Leo Olivers

  ==============================================================================
*/

#ifndef PLATFORM_H_INCLUDED
#define PLATFORM_H_INCLUDED


#include "../JuceLibraryCode/JuceHeader.h"

#if JUCE_WINDOWS

#define EXPORT_VOID    __declspec(dllexport) void  __stdcall
#define EXPORT_INT     __declspec(dllexport) int  __stdcall
#define EXPORT_BOOL    __declspec(dllexport) bool  __stdcall
#define EXPORT_DOUBLE  __declspec(dllexport) double  __stdcall
#define EXPORT_FLOAT   __declspec(dllexport) float  __stdcall

#elif JUCE_IOS

#define EXPORT_VOID    __attribute__((visibility("default"))) void
#define EXPORT_INT     __attribute__((visibility("default"))) int
#define EXPORT_BOOL    __attribute__((visibility("default"))) bool
#define EXPORT_DOUBLE  __attribute__((visibility("default"))) double
#define EXPORT_FLOAT   __attribute__((visibility("default"))) float

#elif JUCE_ANDROID

#define EXPORT_VOID void
#define EXPORT_INT int
#define EXPORT_BOOL bool
#define EXPORT_DOUBLE double
#define EXPORT_FLOAT float

#endif



#endif  // PLATFORM_H_INCLUDED
