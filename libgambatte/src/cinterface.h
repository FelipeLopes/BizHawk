#ifndef CINTERFACE_H
#define CINTERFACE_H

// these are all documented on the C# side
#if defined(_MSC_VER)
	#define GBEXPORT extern "C" __declspec(dllexport)
#elif defined(__GNUC__)
	#define GBEXPORT extern "C" __attribute__((visibility("default")))
#endif

#endif // CINTERFACE_H
