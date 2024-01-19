#include "pch.h"
#include "../../src/StaticLibrary/StaticLibrary.cpp"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace StaticLibraryTests2
{
    TEST_CLASS(StaticLibraryTests2)
    {
    public:

        TEST_METHOD(TestMethod1)
        {
            subtract(1, 2);
        }
    };
}
