﻿using NUnit.Framework;
using VelocyPack.Segments;

namespace VelocyPack.Tests.Segmentation.Arrays
{
    [TestFixture]
    public class FourByteNonIndexedArrayTests
    {
        [Test]
        public void SegmentizeNonIndexedArrayHexDump_With_ZeroZeroByteByteLengthSize()
        {
            // given
            var data = ArrayHexDumps.FourByteNonIndexedWithZeroZeroBytes;

            // when
            var segment = VelocyPack.ToSegment<NonIndexedArraySegment>(data);

            // then
            // array
            Assert.IsInstanceOf<NonIndexedArraySegment>(segment);
            Assert.IsInstanceOf<ArraySegment>(segment);
            Assert.AreEqual(0, segment.StartIndex);
            Assert.AreEqual(data.Length, segment.CursorIndex);
            Assert.AreEqual(data.Length, segment.ByteLength);
            Assert.AreEqual(SegmentType.NonIndexedArray, segment.Type);
            Assert.AreEqual(ValueType.FourByteNonIndexedArray, segment.ValueType);
            Assert.AreEqual(5, segment.ValueStartIndex);
            Assert.AreEqual(3, segment.ValueByteLength);
            Assert.AreEqual(3, segment.Items.Count);

            TestSmallIntegerItems(segment);
        }

        [Test]
        public void SegmentizeNonIndexedArrayHexDump_With_FourZeroByteByteLengthSize()
        {
            // given
            var data = ArrayHexDumps.FourByteNonIndexedWithFourZeroBytes;

            // when
            var segment = VelocyPack.ToSegment<NonIndexedArraySegment>(data);

            // then
            // array
            Assert.IsInstanceOf<NonIndexedArraySegment>(segment);
            Assert.IsInstanceOf<ArraySegment>(segment);
            Assert.AreEqual(0, segment.StartIndex);
            Assert.AreEqual(data.Length, segment.CursorIndex);
            Assert.AreEqual(data.Length, segment.ByteLength);
            Assert.AreEqual(SegmentType.NonIndexedArray, segment.Type);
            Assert.AreEqual(ValueType.FourByteNonIndexedArray, segment.ValueType);
            Assert.AreEqual(9, segment.ValueStartIndex);
            Assert.AreEqual(3, segment.ValueByteLength);
            Assert.AreEqual(3, segment.Items.Count);

            TestSmallIntegerItems(segment);
        }

        private void TestSmallIntegerItems(NonIndexedArraySegment segment)
        {
            // first item
            var item1 = segment.Items[0];

            Assert.IsInstanceOf<SmallIntegerSegment>(item1);
            Assert.AreEqual(SegmentType.SmallInteger, item1.Type);
            Assert.AreEqual(ValueType.PosOneInt, item1.ValueType);

            // second item
            var item2 = segment.Items[1];

            Assert.IsInstanceOf<SmallIntegerSegment>(item2);
            Assert.AreEqual(SegmentType.SmallInteger, item2.Type);
            Assert.AreEqual(ValueType.PosTwoInt, item2.ValueType);

            // third item
            var item3 = segment.Items[2];

            Assert.IsInstanceOf<SmallIntegerSegment>(item3);
            Assert.AreEqual(SegmentType.SmallInteger, item3.Type);
            Assert.AreEqual(ValueType.PosThreeInt, item3.ValueType);
        }
    }
}
