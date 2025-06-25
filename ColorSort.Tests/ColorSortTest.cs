using Xunit;
using ColorSort.Models;
using ColorSort.Services;
using System;

namespace ColorSort.Tests
{
    public class ���������������������
    {
        // �������� ���������� �� ��������� �������
        [Fact]
        public void ����������_������������������_�������������������()
        {
            var ������������� = new[]
            {
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Red
            };

            var ����������������� = new[]
            {
                ColorObject.Red,
                ColorObject.Green,
                ColorObject.Blue
            };

            var ������������������ = new[]
            {
                ColorObject.Red,
                ColorObject.Green,
                ColorObject.Blue
            };

            var ��������� = ColorSorter.Sort(�������������, �����������������);

            Assert.Equal(������������������, ���������);
        }

        // �������� ��������� ������ ������ � ������� ����������
        [Fact]
        public void ����������_���������������_����������������������()
        {
            var ������������� = new[]
            {
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Red,
                ColorObject.Green
            };

            var ����������������� = new[]
            {
                ColorObject.Red,
                ColorObject.Blue
            };

            // ������� �� ������ � �������, ������ ���� ���������
            var ������������������ = new[]
            {
                ColorObject.Red,
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Green
            };

            var ��������� = ColorSorter.Sort(�������������, �����������������);

            Assert.Equal(������������������, ���������);
        }

        // �������� ���������� � ����������� ������
        [Fact]
        public void ����������_������������������_������������������()
        {
            var ������������� = new[]
            {
                ColorObject.Blue,
                ColorObject.Red,
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Red
            };

            var ����������������� = new[]
            {
                ColorObject.Green,
                ColorObject.Red,
                ColorObject.Blue
            };

            var ������������������ = new[]
            {
                ColorObject.Green,
                ColorObject.Red,
                ColorObject.Red,
                ColorObject.Blue,
                ColorObject.Blue
            };

            var ��������� = ColorSorter.Sort(�������������, �����������������);

            Assert.Equal(������������������, ���������);
        }
    }
}