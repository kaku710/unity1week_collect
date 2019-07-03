﻿namespace Communication{
    public static class GameInfo{
        public static readonly int DEFAULT_MONEY = 10000;
        public static readonly int DEFAULT_PERSON_PRODUCTIVITY = 1;
        public static readonly float DEFAULT_SECONDS_PRODUCTIVITY = 10f;
        public static readonly float DEFAULT_STAY_TIME = 5f;
        public static readonly int MAX_SNS_LEVEL = 16;
    }

    public static class CommandInfo{
        public static readonly int[] SNS_MONEY_ARRAY = new int[16]{
            0,
            1000,
            3000,
            5000,
            10000,
            25000,
            50000,
            100000,
            150000,
            200000,
            300000,
            500000,
            1000000,
            2000000,
            3000000,
            5000000
        };
        public static readonly int[] SNS_FOLLOWER_ARRAY = new int[16]{
            0,
            100,
            200,
            500,
            1000,
            2000,
            5000,
            10000,
            30000,
            50000,
            100000,
            150000,
            200000,
            300000,
            500000,
            1000000
        };   
    }
}