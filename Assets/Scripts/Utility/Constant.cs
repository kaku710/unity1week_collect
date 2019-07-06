namespace Communication{
    public static class GameInfo{
        public static readonly int DEFAULT_MONEY = 900000000;
        public static readonly int DEFAULT_PERSON_PRODUCTIVITY = 1;
        public static readonly float DEFAULT_SECONDS_PRODUCTIVITY = 4f;
        public static readonly float DEFAULT_STAY_TIME = 10f;
        public static readonly int MAX_SNS_LEVEL = 17;
        public static readonly int MAX_PART_TIME_LEVEL = 14;
        public static readonly int MAX_MENU_COUNT = 20;
        public static readonly int MAX_SEAT_LEVEL = 8;
        public static readonly int DEFAULT_MIN_MONEY_PER_TAP = 20;
        public static readonly int DEFAULT_MAX_MONEY_PER_TAP = 30;
        public static readonly int CLEAR_MONEY = 1000000000;
    }

    public static class CommandInfo{
        public static readonly int[] SNS_COST_ARRAY = new int[17]{
            2000,
            4500,
            8000,
            15000,
            30000,
            50000,
            80000,
            150000,
            300000,
            500000,
            800000,
            1000000,
            2000000,
            3500000,
            5000000,
            8000000,
            10000000
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
            35000,
            70000,
            150000,
            300000,
            500000,
            700000,
            1000000,
            2000000,
            3000000,
        };  
        public static readonly int[] PART_JOB_COST_ARRAY = new int[15]{
            100000,
            150000,
            200000,
            300000,
            500000,
            750000,
            1000000,
            1300000,
            1800000,
            2400000,
            3000000,
            5000000,
            7000000,
            10000000,
            15000000
        }; 
         public static readonly int[] MENU_COUNT_COST_ARRAY = new int[21]{
            1000,
            3000,
            5000,
            10000,
            20000,
            50000,
            100000,
            200000,
            300000,
            450000,
            600000,
            800000,
            1000000,
            1500000,
            2000000,
            3000000,
            5000000,
            7000000,
            10000000,
            15000000,
            20000000
        }; 
        public static readonly int[] CHARGE_ARRAY = new int[21]{
            500,
            1000,
            1500,
            2000,
            3000,
            5000,
            7000,
            10000,
            15000,
            20000,
            25000,
            35000,
            50000,
            70000,
            90000,
            120000,
            150000,
            180000,
            210000,
            250000,
            300000
        };
        public static readonly int[] SEAT_COUNT_ARRAY = new int[8]{
            4,
            8,
            12,
            16,
            20,
            24,
            28,
            32
        };
        public static readonly int[] SEAT_COST_ARRAY = new int[8]{
            150000,
            500000,
            1000000,
            2000000,
            5000000,
            10000000,
            20000000,
            30000000
        };
    }
}