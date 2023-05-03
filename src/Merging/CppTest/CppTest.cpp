#include "pch.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace CppTest
{
	TEST_CLASS(CppTest)
	{
	private:
		bool m_is32Bit;
		bool m_is64Bit;
		bool m_isAll;
	public:
		CppTest()
		{
#if _WIN64
			m_is64Bit = true;
			m_is32Bit = false;
#else
			m_is64Bit = false;
			m_is32Bit = true;
#endif
			m_isAll = true;
		}

#if _WIN64
		TEST_METHOD(Test_x64)
		{
			Assert::IsFalse(m_is32Bit);
			Assert::IsTrue(m_is64Bit);
			Assert::IsTrue(m_isAll);
		}
#else
		TEST_METHOD(Test_x86)
		{
			Assert::IsTrue(m_is32Bit);
			Assert::IsFalse(m_is64Bit);
			Assert::IsTrue(m_isAll);
		}
#endif
	};
}
