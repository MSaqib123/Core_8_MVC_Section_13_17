namespace TestXUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //========= 1. Arrange =============
            MyMath m = new MyMath();
            int a = 10, b = 5;
            int expectValue = 15;

            //========= 2. Act =============
            int actual = m.Add(a,b);

            //========= 3. Assert =============
            Assert.Equal(expectValue,actual);

            //--- View => TestExplorer(CTR+E+T) => Run => se result
        }
    }
}