using NUnit.Framework;

namespace BinaryTree;

[TestFixture]
public class BinaryTreeTests
{
   [Test]
   public void Tree1()
   {
      // arrange
      var n = new BinaryNode<int>(1);
      n.Insert(2);
      n.Insert(3);
      n.Print();

      // assert
      Assert.That(n.Find(1)?.Value, Is.EqualTo(1));
      Assert.That(n.Find(2)?.Value, Is.EqualTo(2));
      Assert.That(n.Find(3)?.Value, Is.EqualTo(3));
      Assert.That(n.BalanceFactor, Is.EqualTo(2));
      Assert.That(n.Height, Is.EqualTo(3));
      Assert.That(n.Count(), Is.EqualTo(3));
   }

   [TestCase(true)]
   [TestCase(false)]
   public void Tree2(bool balance)
   {
      // arrange
      var n = new BinaryNode<int>(1);
      n.Insert(2);
      n.Insert(3);
      n.Print();

      // act
      n = balance ? n.Balance() : n.RotateLeft();
      n.Print();

      // assert
      Assert.That(n.Find(1)?.Value, Is.EqualTo(1));
      Assert.That(n.Find(2)?.Value, Is.EqualTo(2));
      Assert.That(n.Find(3)?.Value, Is.EqualTo(3));
      Assert.That(n.BalanceFactor, Is.EqualTo(0));
      Assert.That(n.Height, Is.EqualTo(2));
      Assert.That(n.Count(), Is.EqualTo(3));
   }

   [TestCase(true)]
   [TestCase(false)]
   public void Tree3(bool balance)
   {
      // arrange
      var n = new BinaryNode<int>(3);
      n.Insert(2);
      n.Insert(1);
      n.Print();

      // act
      n = balance ? n.Balance() : n.RotateRight();
      n.Print();

      // assert
      Assert.That(n.Find(1)?.Value, Is.EqualTo(1));
      Assert.That(n.Find(2)?.Value, Is.EqualTo(2));
      Assert.That(n.Find(3)?.Value, Is.EqualTo(3));
      Assert.That(n.BalanceFactor, Is.EqualTo(0));
      Assert.That(n.Height, Is.EqualTo(2));
      Assert.That(n.Count(), Is.EqualTo(3));
   }

   [TestCase(true)]
   [TestCase(false)]
   public void Tree4(bool balance)
   {
      // arrange
      var n = new BinaryNode<int>(1);
      n.Insert(3);
      n.Insert(2);
      n.Print();

      // act
      n = balance ? n.Balance() : n.RotateLeft();
      n.Print();

      // assert
      Assert.That(n.BalanceFactor, Is.EqualTo(0));
      Assert.That(n.Height, Is.EqualTo(2));
      Assert.That(n.Count(), Is.EqualTo(3));
   }

   [TestCase(true)]
   [TestCase(false)]
   public void Tree5(bool balance)
   {
      // arrange
      var n = new BinaryNode<int>(3);
      n.Insert(1);
      n.Insert(2);
      n.Print();

      // act
      n = balance ? n.Balance() : n.RotateRight();
      n.Print();

      // assert
      Assert.That(n.BalanceFactor, Is.EqualTo(0));
      Assert.That(n.Height, Is.EqualTo(2));
      Assert.That(n.Count(), Is.EqualTo(3));
   }


   [Test]
   public void Tree6()
   {
      // arrange
      var n = new BinaryNode<int>(1);
      for (int i = 2; i <= 7; i++)
      {
         n.Insert(i);
      }

      // assume
      Assert.That(n.Count(), Is.EqualTo(7));

      // act
      n = n.Balance();

      // assert
      n.Print();
      Assert.That(n.BalanceFactor, Is.EqualTo(0));
      Assert.That(n.Height, Is.EqualTo(3));
      Assert.That(n.Count(), Is.EqualTo(7));
   }
}