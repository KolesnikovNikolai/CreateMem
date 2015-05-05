using CreateMems;
using NUnit.Framework;
using System;
using System.Drawing;
using System.Text;

namespace TestsCreateMem
{
    public class TestsNunit
    {
        [Test]
        public void TestLoadImage() {
            CreateMem createMem = new CreateMem();
            createMem.LoadImage("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            Assert.That(createMem.getImage(), Is.Not.EqualTo(null));
        }
        [Test]
        public void TestLoadImage2()
        {
            CreateMem createMem = new CreateMem();
            createMem.LoadImage("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            Bitmap bmp = new Bitmap("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            Bitmap result = createMem.getImage();
            for (int i = 0; i < result.Width; i++)
                for (int j = 0; j < result.Height;j++ )
                    Assert.AreEqual(result.GetPixel(i,j), bmp.GetPixel(i,j));

        }

        [Test]
        public void TestSaveImage()
        {
            CreateMem createMem = new CreateMem();
            createMem.LoadImage("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            createMem.SaveImage("C:\\Users\\win02011993\\Pictures\\pi2.jpg");
            Bitmap bmp = createMem.getImage();
            Bitmap result = new Bitmap("C:\\Users\\win02011993\\Pictures\\pi2.jpg");
            for (int i = 0; i < result.Width; i++)
                for (int j = 0; j < result.Height; j++)
                    Assert.AreEqual(result.GetPixel(i, j), bmp.GetPixel(i, j));

        }
        [Test]
        public void TestSetUpText()
        {
            CreateMem createMem = new CreateMem();
            String str = "Интересно, а кто-нибудь";
            createMem.SetUpText(str);
                    Assert.AreEqual(str, createMem.getUpText());

        }
        [Test]
        public void TestSetDownText()
        {
            CreateMem createMem = new CreateMem();
            String str = "проверял торт???";
            createMem.SetDownText(str);
            Assert.AreEqual(str, createMem.getDownText());

        }
        [Test]
        public void TestSetTextOnImage()
        {
            CreateMem createMem = new CreateMem();
            createMem.LoadImage("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            Bitmap bmp = new Bitmap("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            createMem.SetTextOnImage(10, 10, 584, 431, "Привет");
            Bitmap result = createMem.getImage();
            bool f = false;
            for (int i = 10; i <= 594; i++)
                for (int j = 10; j <= 441; j++)
                    if (!bmp.GetPixel(i, j).Equals(result.GetPixel(i,j)))
                    {
                        f = true;
                        break;
                    }
            Assert.IsTrue(f);
        }
        [Test]
        public void TestSetTextOnImageUp()
        {
            CreateMem createMem = new CreateMem();
            createMem.LoadImage("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            Bitmap bmp = new Bitmap("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            createMem.SetUpText("Иногда охота взять и...");
            createMem.SetTextOnImageUp();
            Bitmap result = createMem.getImage();
            bool f = false;
                for (int j = 10; j < result.Height; j++)
                    if (!bmp.GetPixel(bmp.Width / 2, j).Equals(result.GetPixel(result.Width / 2, j)))
                    {
                        f = true;
                        break;
                    }
            Assert.IsTrue(f);
        }
        [Test]
        public void TestSetTextOnImageDown()
        {
            CreateMem createMem = new CreateMem();
            createMem.LoadImage("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            Bitmap bmp = new Bitmap("C:\\Users\\win02011993\\Pictures\\pi.jpg");
            createMem.SetDownText("отдохнуть");
            createMem.SetTextOnImageDown();
            Bitmap result = createMem.getImage();
            bool f = false;
            for (int j = 0; j < result.Height; j++)
                if (!bmp.GetPixel(bmp.Width / 2, j).Equals(result.GetPixel(result.Width / 2, j)))
                {
                    f = true;
                    break;
                }
            Assert.IsTrue(f);
        }
    }
}
