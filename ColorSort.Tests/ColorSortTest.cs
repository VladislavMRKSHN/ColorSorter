using Xunit;
using ColorSort.Models;
using ColorSort.Services;
using System;

namespace ColorSort.Tests
{
    public class “есты—ортировки÷ветов
    {
        // ѕроверка сортировки по заданному пор€дку
        [Fact]
        public void —ортировка_ѕо«аданномуѕор€дку_ орректный–езультат()
        {
            var входныеƒанные = new[]
            {
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Red
            };

            var пор€док—ортировки = new[]
            {
                ColorObject.Red,
                ColorObject.Green,
                ColorObject.Blue
            };

            var ожидаемый–езультат = new[]
            {
                ColorObject.Red,
                ColorObject.Green,
                ColorObject.Blue
            };

            var результат = ColorSorter.Sort(входныеƒанные, пор€док—ортировки);

            Assert.Equal(ожидаемый–езультат, результат);
        }

        // ѕроверка неполного набора цветов в пор€дке сортировки
        [Fact]
        public void —ортировка_Ќеполныйѕор€док_Ќеуказанные÷вета¬ онце()
        {
            var входныеƒанные = new[]
            {
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Red,
                ColorObject.Green
            };

            var пор€док—ортировки = new[]
            {
                ColorObject.Red,
                ColorObject.Blue
            };

            // «еленый не указан в пор€дке, должен быть последним
            var ожидаемый–езультат = new[]
            {
                ColorObject.Red,
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Green
            };

            var результат = ColorSorter.Sort(входныеƒанные, пор€док—ортировки);

            Assert.Equal(ожидаемый–езультат, результат);
        }

        // ѕроверка сортировки с дубликатами цветов
        [Fact]
        public void —ортировка_ѕовтор€ющиес€÷вета_—охран€етс€ѕор€док()
        {
            var входныеƒанные = new[]
            {
                ColorObject.Blue,
                ColorObject.Red,
                ColorObject.Blue,
                ColorObject.Green,
                ColorObject.Red
            };

            var пор€док—ортировки = new[]
            {
                ColorObject.Green,
                ColorObject.Red,
                ColorObject.Blue
            };

            var ожидаемый–езультат = new[]
            {
                ColorObject.Green,
                ColorObject.Red,
                ColorObject.Red,
                ColorObject.Blue,
                ColorObject.Blue
            };

            var результат = ColorSorter.Sort(входныеƒанные, пор€док—ортировки);

            Assert.Equal(ожидаемый–езультат, результат);
        }
    }
}