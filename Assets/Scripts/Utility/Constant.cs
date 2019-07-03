namespace Communication{
    public static class GameInfo{
        public static readonly int DEFAULT_MONEY = 1000;
        public static readonly int DEFAULT_PERSON_PRODUCTIVITY = 1;
        public static readonly float DEFAULT_SECONDS_PRODUCTIVITY = 10f;
        public static readonly float DEFAULT_STAY_TIME = 5f;
        public static readonly int MAX_SNS_LEVEL = 17;
        public static readonly int MAX_PART_TIME_LEVEL = 16;
        public static readonly int MAX_MENU_COUNT = 17;
        public static readonly int MAX_SEAT_LEVEL = 11;
    }

    public static class CommandInfo{
        public static readonly int[] SNS_COST_ARRAY = new int[17]{
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
            5000000,
            10000000,
            20000000
        };
        public static readonly int[] SNS_FOLLOWER_ARRAY = new int[17]{
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
            750000,
            1000000,
        };  
        public static readonly int[] PART_JOB_COST_ARRAY = new int[17]{
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
            5000000,
            10000000,
            20000000
        }; 
         public static readonly int[] MENU_COUNT_COST_ARRAY = new int[17]{
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
            5000000,
            10000000,
            20000000
        }; 
        public static readonly int[] SEAT_COUNT_ARRAY = new int[11]{
            5,
            7,
            10,
            15,
            20,
            25,
            30,
            35,
            40,
            45,
            50
        };
        public static readonly int[] SEAT_COST_ARRAY = new int[11]{
            100000,
            150000,
            200000,
            300000,
            500000,
            1000000,
            2000000,
            3000000,
            5000000,
            10000000,
            20000000
        };
    }
}