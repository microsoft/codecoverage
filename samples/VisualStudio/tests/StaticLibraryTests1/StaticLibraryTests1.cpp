#include "pch.h"
#include "../../src/StaticLibrary/StaticLibrary.cpp"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace StaticLibraryTests1
{
    TEST_CLASS(StaticLibraryTests1)
    {
    public:

        TEST_METHOD(TestMethod1)
        {
            add(1, 2);
        }
    };
}
