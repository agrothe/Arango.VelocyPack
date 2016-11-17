﻿using NUnit.Framework;
using VelocyPack.Segments;

namespace VelocyPack.Tests.SegmentParsing.Arrays
{
    [TestFixture]
    public class TwoByteNonIndexedArrayTests
    {
        [Test]
        public void ParseArrayWithSmallIntegerSubSegments()
        {
            // given
            // hex dump of [1, 2, 3]
            var data = new byte[] { 0x03, 0x06, 0x00, 0x31, 0x32, 0x33 };

            // when
            var segment = VelocyPack.ToSegment(data);

            // then
            // array
            Assert.IsInstanceOf<NonIndexedArraySegment>(segment);
            Assert.AreEqual(0, segment.StartIndex);
            Assert.AreEqual(6, segment.CursorIndex);
            Assert.AreEqual(data.Length, segment.ByteLength);
            Assert.AreEqual(SegmentType.NonIndexedArray, segment.Type);
            Assert.AreEqual(ValueType.TwoByteNonIndexedArray, segment.ValueType);
            Assert.AreEqual(3, segment.SubSegments.Count);

            // first small integer sub segment
            var subSegment1 = segment.SubSegments[0];

            Assert.IsInstanceOf<SmallIntegerSegment>(subSegment1);
            Assert.AreEqual(3, subSegment1.StartIndex);
            Assert.AreEqual(4, subSegment1.CursorIndex);
            Assert.AreEqual(SegmentType.SmallInteger, subSegment1.Type);
            Assert.AreEqual(ValueType.PosOneInt, subSegment1.ValueType);
            Assert.IsNull(subSegment1.SubSegments);

            // second small integer sub segment
            var subSegment2 = segment.SubSegments[1];

            Assert.IsInstanceOf<SmallIntegerSegment>(subSegment2);
            Assert.AreEqual(4, subSegment2.StartIndex);
            Assert.AreEqual(5, subSegment2.CursorIndex);
            Assert.AreEqual(SegmentType.SmallInteger, subSegment2.Type);
            Assert.AreEqual(ValueType.PosTwoInt, subSegment2.ValueType);
            Assert.IsNull(subSegment2.SubSegments);

            // third small integer sub segment
            var subSegment3 = segment.SubSegments[2];

            Assert.IsInstanceOf<SmallIntegerSegment>(subSegment3);
            Assert.AreEqual(5, subSegment3.StartIndex);
            Assert.AreEqual(6, subSegment3.CursorIndex);
            Assert.AreEqual(SegmentType.SmallInteger, subSegment3.Type);
            Assert.AreEqual(ValueType.PosThreeInt, subSegment3.ValueType);
            Assert.IsNull(subSegment3.SubSegments);
        }
    }
}