namespace CsharpDynamicJsonBestPractice.Model
{
    public class ConfigModel
    {
        /// <summary>
        /// 名前。
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 年齢。
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// 体重。
        /// </summary>
        public double weight { get; set; }

        /// <summary>
        /// 生きてた所。
        /// </summary>
        public string[] livingList { get; set; }

        /// <summary>
        /// ラッキーナンバー リスト。
        /// </summary>
        public double[] lackyNumberList { get; set; }

        // 連想配列の形になっている dishMap は、Deserialize では取れない。DynamicJson型から直接取る。

        /// <summary>
        /// 玩具。
        /// </summary>
        public class Toy
        {
            /// <summary>
            /// 名前。
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 最小プレイヤー人数。
            /// </summary>
            public int playerMin { get; set; }

            /// <summary>
            /// 最大プレイヤー人数。
            /// </summary>
            public int playerMax { get; set; }
        }

        /// <summary>
        /// 玩具。
        /// </summary>
        public Toy toy { get; set; }

    }
}
