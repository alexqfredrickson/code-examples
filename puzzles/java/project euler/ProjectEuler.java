/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projecteuler;

import java.io.*;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.math.BigInteger;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 *
 * @author thePOMPANO
 */
public class ProjectEuler {

    /**
     * @param args the command line arguments
     * @throws java.io.IOException
     *
     */
    public static void main(String[] args) throws IOException {
        euler22();
    }
    
    public static void euler1() {
        int sum = 0;
        for (int i = 1; i < 1000; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        System.out.print(sum);
    }
    
    public static void euler2() {
        int evenSums = 0;
        int fib1 = 0;
        int fib2 = 1;
        int fibNext;
        
        while (fib1 <= 4000000 && fib2 <= 4000000) {
            fibNext = fib1 + fib2;
            if (fibNext % 2 == 0) {
                evenSums += fibNext;
            }
            fib1 = fib2;
            fib2 = fibNext;
        }
        System.out.print(evenSums);
    }
    
    public static void euler3() {
        long x = 600851475143L;

        for (long i = 3L; i < Math.sqrt(x); i += 2) {
            if (utils.isPrime(i) && x % i == 0) {
                System.out.println(i);
            }
        }
    }

    public static void euler4() {
        int largestPalindrome = 0;
        for (int multiplier = 100; multiplier <= 999; multiplier++) {
            for (int multiplicand = 100; multiplicand <= 999; multiplicand++) {
                if (utils.isPalindrome(String.valueOf(multiplier * multiplicand))) {
                    if (multiplier * multiplicand >= largestPalindrome) largestPalindrome = multiplier * multiplicand;
                }
            }
        }
        System.out.print(largestPalindrome);
    }
    
    public static void euler5() {
        int result = 0;
        int n = 2520;
        
        while (result == 0) {
            for (int i = 2; i <= 20; i++) {
                if (n % i != 0) {
                    n += 20;
                    break;
                }   else if (i == 20 && n % i == 0) {
                    result = n;
                    System.out.print(result);
                }
            }
        }
    }
    
    public static void euler6() {
        long sumSquares = 0;
        long squaredSums;
        
        for (int i = 1; i <= 100; i++) {
            sumSquares += i*i;
        }
        
        int sum = 0;
        for (int i = 1; i <= 100; i++) {
            sum += i;
        }
        squaredSums = sum * sum;
        
        System.out.print(Math.abs(squaredSums - sumSquares));
    }
    
    public static void euler7() {
        ArrayList<Integer> primes = new ArrayList();
        int n = 1;
        while (primes.size() <= 10000) {
            if (n % 2 == 0) {
                n += 1;
                continue;
            }
            if (utils.isPrime(n)) {
                primes.add(n);
            }
            n += 2;
        }
        System.out.print(primes.get(10000));
    }
    
    public static void euler8() {
        String numberlist = "73167176531330624919225119674426574742355349194934\n"
                + "96983520312774506326239578318016984801869478851843\n"
                + "85861560789112949495459501737958331952853208805511\n"
                + "12540698747158523863050715693290963295227443043557\n"
                + "66896648950445244523161731856403098711121722383113\n"
                + "62229893423380308135336276614282806444486645238749\n"
                + "30358907296290491560440772390713810515859307960866\n"
                + "70172427121883998797908792274921901699720888093776\n"
                + "65727333001053367881220235421809751254540594752243\n"
                + "52584907711670556013604839586446706324415722155397\n"
                + "53697817977846174064955149290862569321978468622482\n"
                + "83972241375657056057490261407972968652414535100474\n"
                + "82166370484403199890008895243450658541227588666881\n"
                + "16427171479924442928230863465674813919123162824586\n"
                + "17866458359124566529476545682848912883142607690042\n"
                + "24219022671055626321111109370544217506941658960408\n"
                + "07198403850962455444362981230987879927244284909188\n"
                + "84580156166097919133875499200524063689912560717606\n"
                + "05886116467109405077541002256983155200055935729725\n"
                + "71636269561882670428252483600823257530420752963450";
        numberlist = numberlist.replaceAll("\n", "");

        int biggestProduct = 0;

        for (int i = 5; i < numberlist.length(); i++) {
            int product = Integer.parseInt(numberlist.substring(i-5, i-4)) * 
                        Integer.parseInt(numberlist.substring(i-4, i-3)) * 
                        Integer.parseInt(numberlist.substring(i-3, i-2)) * 
                        Integer.parseInt(numberlist.substring(i-2, i-1)) * 
                        Integer.parseInt(numberlist.substring(i-1, i));
            biggestProduct = Math.max(biggestProduct, product);
        }
        System.out.print(biggestProduct);
    }
    
    public static void euler9() {
        int[] possiblea = new int[500];
        int[] possibleb = new int[500];
        int[] possiblec = new int[500];

        for (int i = 0; i < 500; i++) {
            possiblea[i] = i + 1;
            possibleb[i] = i + 1;
            possiblec[i] = i + 1;
        }
        // a b and c represent all possible a b and c values
        // is there a c such that sqrt(a^2 + b^2) == c?

        for (int i = 0; i < 500; i++) { // a
            for (int j = 0; j < 500; j++) { // b
                if (j < i) {
                    continue;
                }
                for (int k = 0; k < 500; k++) {// c
                    if (k < j) {
                        continue;
                    }
                    if ((possiblea[i] + possibleb[j] + possiblec[k]) == 1000 && possiblec[k] == Math.sqrt(possiblea[i] * possiblea[i] + possibleb[j] * possibleb[j])) {
                        System.out.println(possiblea[i] + " " + possibleb[j] + " " + possiblec[k]);
                    }
                }
            }

        }
    }

    public static void euler10() {
        int n = 2000000;
        int[] ints = new int[n];
        int[] primes = new int[n];

        // n represents the max number to test (e.g. all integers from 0 to n)
        // the program checks all values underneath n (*if n is prime, n itself is not counted*)
        // ints represents all of int values from 0 to n
        // primes has one of three values: 0 (not prime), 1 (prime), or 2 (unevaluated)
        for (int i = 0; i < ints.length; i++) {
            ints[i] = i;
        }

        // ints[x] = x, where x <= n-1
        for (int i = 0; i < primes.length; i++) {
            primes[i] = 2;
        }

        // all primes are currently unevaluated, or "2"
        primes[0] = 0;
        primes[1] = 0;

        // 0 and 1 are not primes
        int nextMultiple = 0;

        // initializes nextMultiple; which is the first unevaluated number that
        // the second for loop finds.  this is always a prime number
        while (nextMultiple < n) {

            // if nextMultiple exceeds the highest possible int (i.e. n), *everything* stops
            for (int i = 0; i < primes.length; i++) {
                if (primes[i] == 2) {
                    nextMultiple = ints[i];
                    break;
                }

                // if primes[i] is unevaluated, ints[i] is a prime number, and the
                // multiples of ints[i] are set to false:
                if (i == (primes.length - 1) && primes[i] != 2) {
                    nextMultiple = n;
                    break;
                }

                // the stop condition: all primes[i] are evaluated (i.e., 0 or 1)
                // nextMultiple = n breaks the while loop
            }

            for (int i = nextMultiple; i < primes.length; i += nextMultiple) {
                if (ints[i] == nextMultiple) {
                    primes[i] = 1;
                } else {
                    primes[i] = 0;
                }
            }

        }

        // the second for loop makes all multiples of nextMultiple false
        // and then sets primes[nextMultiple] as true
        long sum = 0;
        for (int i = 0; i < ints.length; i++) {
            if (primes[i] == 1) {
                sum += ints[i];
            }
        }
        System.out.println(sum);

        // all primes between 0 and n-1 are added up and spit back out
    }
    
    public static void euler10v2() {
        HashSet<Integer> primes = new HashSet();
        long sumPrimes = 0;

        primes.add(2);

        for (int i = 3; i <= 2000000; i += 2) {
            if (utils.isPrime(i)) {
                primes.add(i);
            }
        }
        for (int prime : primes) {
            sumPrimes += prime;
        }
        System.out.print(sumPrimes);
    }

    public static void euler11() {
        String str = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08 "
                + "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00 "
                + "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65 "
                + "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91 "
                + "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 "
                + "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50 "
                + "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 "
                + "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21 "
                + "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 "
                + "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95 "
                + "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92 "
                + "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57 "
                + "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58 "
                + "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40 "
                + "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66 "
                + "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69 "
                + "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36 "
                + "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16 "
                + "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54 "
                + "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48 ";

        int[] intarray = new int[400];
        int biggest = 0;

        //establishes the intarray
        for (int i = 0; i < str.length() / 3; i++) {
            intarray[i] = Integer.parseInt(str.substring(i * 3, (i * 3) + 2));
        }

        // intarray now contains all values from 0 to 399
        // find the max value for up and down
        for (int i = 1; i <= 340; i++) {
            biggest = Math.max(biggest, intarray[i - 1] * intarray[i + 19] * intarray[i + 39] * intarray[i + 59]);
        }

        // left and right
        for (int i = 1; i <= 400; i++) {
            if (i % 20 == 0 || (i % 20 >= 17 && i % 20 <= 19)) {
                continue;
            }
            biggest = Math.max(biggest, intarray[i - 1] * intarray[i] * intarray[i + 2] * intarray[i + 3]);
        }

        for (int i = 1; i <= 338; i++) {
            if (i % 20 == 18 || i % 20 == 19 || i % 20 == 0) {
                continue;
            }
            biggest = Math.max(biggest, intarray[i - 1] * intarray[i + 20] * intarray[i + 41] * intarray[i + 62]);
        }

        for (int i = 1; i <= 340; i++) {
            if (i % 20 >= 1 && i % 20 <= 3) {
                continue;
            }
            biggest = Math.max(biggest, intarray[i - 1] * intarray[i + 18] * intarray[i + 37] * intarray[i + 56]);
        }

        System.out.print(biggest);
    }

    public static void euler12() {
        long trianglen = 1;
        long triangle = 1;
        boolean stop = true;
        while (stop == true) {
            if (utils.numberOfFactors(triangle) >= 250) {
                stop = false;
            } else {
                trianglen++;
                triangle = (trianglen * (trianglen + 1)) / 2;
            }
        }
        System.out.print(triangle);
    }

    public static void euler13() {
        String a = "37107287533902102798797998220837590246510135740250\n"
                + "46376937677490009712648124896970078050417018260538\n"
                + "74324986199524741059474233309513058123726617309629\n"
                + "91942213363574161572522430563301811072406154908250\n"
                + "23067588207539346171171980310421047513778063246676\n"
                + "89261670696623633820136378418383684178734361726757\n"
                + "28112879812849979408065481931592621691275889832738\n"
                + "44274228917432520321923589422876796487670272189318\n"
                + "47451445736001306439091167216856844588711603153276\n"
                + "70386486105843025439939619828917593665686757934951\n"
                + "62176457141856560629502157223196586755079324193331\n"
                + "64906352462741904929101432445813822663347944758178\n"
                + "92575867718337217661963751590579239728245598838407\n"
                + "58203565325359399008402633568948830189458628227828\n"
                + "80181199384826282014278194139940567587151170094390\n"
                + "35398664372827112653829987240784473053190104293586\n"
                + "86515506006295864861532075273371959191420517255829\n"
                + "71693888707715466499115593487603532921714970056938\n"
                + "54370070576826684624621495650076471787294438377604\n"
                + "53282654108756828443191190634694037855217779295145\n"
                + "36123272525000296071075082563815656710885258350721\n"
                + "45876576172410976447339110607218265236877223636045\n"
                + "17423706905851860660448207621209813287860733969412\n"
                + "81142660418086830619328460811191061556940512689692\n"
                + "51934325451728388641918047049293215058642563049483\n"
                + "62467221648435076201727918039944693004732956340691\n"
                + "15732444386908125794514089057706229429197107928209\n"
                + "55037687525678773091862540744969844508330393682126\n"
                + "18336384825330154686196124348767681297534375946515\n"
                + "80386287592878490201521685554828717201219257766954\n"
                + "78182833757993103614740356856449095527097864797581\n"
                + "16726320100436897842553539920931837441497806860984\n"
                + "48403098129077791799088218795327364475675590848030\n"
                + "87086987551392711854517078544161852424320693150332\n"
                + "59959406895756536782107074926966537676326235447210\n"
                + "69793950679652694742597709739166693763042633987085\n"
                + "41052684708299085211399427365734116182760315001271\n"
                + "65378607361501080857009149939512557028198746004375\n"
                + "35829035317434717326932123578154982629742552737307\n"
                + "94953759765105305946966067683156574377167401875275\n"
                + "88902802571733229619176668713819931811048770190271\n"
                + "25267680276078003013678680992525463401061632866526\n"
                + "36270218540497705585629946580636237993140746255962\n"
                + "24074486908231174977792365466257246923322810917141\n"
                + "91430288197103288597806669760892938638285025333403\n"
                + "34413065578016127815921815005561868836468420090470\n"
                + "23053081172816430487623791969842487255036638784583\n"
                + "11487696932154902810424020138335124462181441773470\n"
                + "63783299490636259666498587618221225225512486764533\n"
                + "67720186971698544312419572409913959008952310058822\n"
                + "95548255300263520781532296796249481641953868218774\n"
                + "76085327132285723110424803456124867697064507995236\n"
                + "37774242535411291684276865538926205024910326572967\n"
                + "23701913275725675285653248258265463092207058596522\n"
                + "29798860272258331913126375147341994889534765745501\n"
                + "18495701454879288984856827726077713721403798879715\n"
                + "38298203783031473527721580348144513491373226651381\n"
                + "34829543829199918180278916522431027392251122869539\n"
                + "40957953066405232632538044100059654939159879593635\n"
                + "29746152185502371307642255121183693803580388584903\n"
                + "41698116222072977186158236678424689157993532961922\n"
                + "62467957194401269043877107275048102390895523597457\n"
                + "23189706772547915061505504953922979530901129967519\n"
                + "86188088225875314529584099251203829009407770775672\n"
                + "11306739708304724483816533873502340845647058077308\n"
                + "82959174767140363198008187129011875491310547126581\n"
                + "97623331044818386269515456334926366572897563400500\n"
                + "42846280183517070527831839425882145521227251250327\n"
                + "55121603546981200581762165212827652751691296897789\n"
                + "32238195734329339946437501907836945765883352399886\n"
                + "75506164965184775180738168837861091527357929701337\n"
                + "62177842752192623401942399639168044983993173312731\n"
                + "32924185707147349566916674687634660915035914677504\n"
                + "99518671430235219628894890102423325116913619626622\n"
                + "73267460800591547471830798392868535206946944540724\n"
                + "76841822524674417161514036427982273348055556214818\n"
                + "97142617910342598647204516893989422179826088076852\n"
                + "87783646182799346313767754307809363333018982642090\n"
                + "10848802521674670883215120185883543223812876952786\n"
                + "71329612474782464538636993009049310363619763878039\n"
                + "62184073572399794223406235393808339651327408011116\n"
                + "66627891981488087797941876876144230030984490851411\n"
                + "60661826293682836764744779239180335110989069790714\n"
                + "85786944089552990653640447425576083659976645795096\n"
                + "66024396409905389607120198219976047599490197230297\n"
                + "64913982680032973156037120041377903785566085089252\n"
                + "16730939319872750275468906903707539413042652315011\n"
                + "94809377245048795150954100921645863754710598436791\n"
                + "78639167021187492431995700641917969777599028300699\n"
                + "15368713711936614952811305876380278410754449733078\n"
                + "40789923115535562561142322423255033685442488917353\n"
                + "44889911501440648020369068063960672322193204149535\n"
                + "41503128880339536053299340368006977710650566631954\n"
                + "81234880673210146739058568557934581403627822703280\n"
                + "82616570773948327592232845941706525094512325230608\n"
                + "22918802058777319719839450180888072429661980811197\n"
                + "77158542502016545090413245809786882778948721859617\n"
                + "72107838435069186155435662884062257473692284509516\n"
                + "20849603980134001723930671666823555245252804609722\n"
                + "53503534226472524250874054075591789781264330331690";
        a = a.replace("\n", "");
        BigInteger c = new BigInteger("0");
        for (int i = 0; i < 100; i++) {
            BigInteger b = new BigInteger(a.substring(i * 50, i * 50 + 50));
            c = c.add(b);
        }
        System.out.print(c);
    }

    public static void euler14() {
        long answer = 1;
        long answerCount = 1;

        for (long i = 1; i <= 1000000; i++) {

            long n = i;
            long count = 0;
            while (n != 1) {
                if (n % 2 == 0) {
                    n = n / 2;
                    count++;
                } else {
                    n = 3 * n + 1;
                    count++;
                }
            }
            if (count >= answerCount) {
                answerCount = count;
                answer = i;
            }
        }
        System.out.print(answer);
    }

    public static void euler16() {
        BigInteger a = new BigInteger("2");
        String b;
        a = a.pow(1000);
        b = a.toString();
        int c = 0;
        for (int i = 0; i < b.length(); i++) {
            c += Integer.parseInt(b.substring(i, i + 1));
        }
        System.out.print(c);

    }

    public static void euler18() {
        int[][] triangle = {{75}, {95, 64}, {17, 47, 82},
        {18, 35, 87, 10},
        {20, 4, 82, 47, 65},
        {19, 1, 23, 75, 3, 34},
        {88, 2, 77, 73, 7, 63, 67},
        {99, 65, 4, 28, 6, 16, 70, 92},
        {41, 41, 26, 56, 83, 40, 80, 70, 33},
        {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
        {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
        {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
        {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
        {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
        {4, 62, 98, 27, 23, 9, 70, 98, 73, 93, 38, 53, 60, 04, 23}};

        for (int i = triangle.length - 1; i >= 1; i--) {
            for (int j = 0; j < triangle[i].length - 1; j++) {
                triangle[i - 1][j] += Math.max(triangle[i][j], triangle[i][j + 1]);
            }
        }
        System.out.print(triangle[0][0]);
    }

    public static void euler19() {
        //1 Jan 1900 was a Monday.
        //Thirty days has September(9),
        //April(4), June(6) and November(11).
        //All the rest have thirty-one,
        //Saving February(2) alone,
        //Which has twenty-eight, rain or shine.
        //And on leap years, twenty-nine.
        //A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
        //How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

        int sundayCount = 0;
        int year = 1901;
        int month = 1; // january
        int dayCount = 2; // tuesday

        while (year < 2001) {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
                if (isSunday(dayCount)) {
                    sundayCount++;
                }
                dayCount += 31;
            } else if (month == 4 || month == 6 || month == 9 || month == 11) {
                if (isSunday(dayCount)) {
                    sundayCount++;
                }
                dayCount += 30;
            } else {
                if (isSunday(dayCount)) {
                    sundayCount++;
                }
                if (year % 100 == 0) { // century
                    if (year % 400 == 0) { // leap year century
                        dayCount += 29;
                    } else { // not leap year century
                        dayCount += 28;
                    }
                } else if (year % 4 == 0 && year % 100 != 0) { // leap year not century
                    dayCount += 29;
                } else { // not leap year not century
                    dayCount += 28;
                }
            }
            month++;
            if (month == 13) {
                month = 1;
                year++;
            }
        }
        System.out.print(sundayCount);

    }

    public static boolean isSunday(int day) {
        return (day % 7 == 0);
    }

    public static void euler20() {
        BigInteger sum = BigInteger.valueOf(1);
        for (int i = 1; i < 100; i++) {
            sum = sum.multiply(BigInteger.valueOf(i + 1));
        }
        String c = sum.toString();
        int d = 0;
        for (int i = 0; i < c.length(); i++) {
            d += Integer.parseInt(c.substring(i, i + 1));
        }
        System.out.print(d);
    }

    //TODO: fix this
    public static void euler22() throws FileNotFoundException, MalformedURLException, IOException {
        URL url = new URL("http://www.projecteuler.net/project/names.txt");

        ArrayList<String> nameList = new ArrayList();
        InputStream stream = url.openStream();
        Scanner sc = new Scanner(stream);
        String namesString = sc.nextLine();
        namesString = namesString.replaceAll("\"", "");
        namesString = namesString.replaceAll(",", " ");

        Scanner sc2 = new Scanner(namesString).useDelimiter(" ");
        String name;

        while (sc2.hasNext()) {
            name = sc2.next();
            nameList.add(name);
        }

        Collections.sort(nameList);

        long count = 0;
        int score;
        for (int i = 0; i < nameList.size(); i++) {
            name = nameList.get(i);
            score = 0;
            for (int j = 0; j < name.length(); j++) {
                score += (int) name.charAt(j) - 64;
            }
            count += (i + 1) * score;
        }
        System.out.print(count);

    }

    public static void euler23() {
        ArrayList<Integer> abundants = new ArrayList();

        for (int i = 1; i <= 28123; i++) {
            if (utils.isAbundant(i)) {
                abundants.add(i);
            }
        }

        HashSet<Integer> abundantSums = new HashSet();
        int sum;
        for (int i = 0; i < abundants.size(); i++) {
            for (int j = 0; j < abundants.size(); j++) {
                sum = abundants.get(i) + abundants.get(j);
                if (sum > 28123) {
                    break;
                }
                abundantSums.add(sum);
            }
            abundants.remove(i);
            i--;
        }

        long answer = 0;
        for (int i = 1; i <= 28123; i++) {
            if (abundantSums.contains(i)) {
                continue;
            }
            answer += i;
        }

        System.out.print(answer);

    }

    public static void euler24() throws IOException {
        String str;
        System.out.println("Enter the initial string");
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        str = br.readLine();
        System.out.println("Permutations are :");
        HashSet<String> a = new HashSet();
        utils.permute("", str, a);
        String[] b = new String[a.size()];
        a.toArray(b);
        for (String s : b) {
            System.out.println(s);
        }

    }

    public static void euler27() {
        long n;
        int consecutivePrimeCount;
        int highestPrimeCount = 0;
        int highestProduct = 0;

        for (int a = -999; a < 1000; a++) {
            for (int b = -999; b < 1000; b++) {
                n = 0;
                consecutivePrimeCount = 0;
                while (utils.isPrime((long) (Math.pow(n, 2) + (n * a) + b))) {
                    n++;
                    consecutivePrimeCount++;
                    if (consecutivePrimeCount >= highestPrimeCount) {
                        highestProduct = a * b;
                        highestPrimeCount = (int) n;
                    }
                }

            }
        }
        System.out.print(highestProduct);

    }

    public static void euler28() {
        int sum = 1;
        int count = 2;
        int subCount = 0;
        for (int i = 3; i <= 1002001; i += count) {
            sum += i;
            subCount++;
            if (subCount == 4) {
                subCount = 0;
                count += 2;
            }
        }
        System.out.print(sum);

    }

    public static void euler30() {
        // TODO code application logic here
        int number = 0;

        for (int i = 1000000; i >= 10; i--) {
            if (utils.digitFifth(i)) {
                number += i;
            }

        }
        System.out.print(number);
    }

    public static void euler32() {
        /*We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once;
         for example, the 5-digit number, 15234, is 1 through 5 pandigital.
         The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
         Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
         HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.*/

        //find all pandigital numbers, from 1 to 987654321, and note that all of the pandigital numbers are permutations of 1 to n, where !(0 > n > 9)
        HashSet<Integer> pandigitals = new HashSet<>();
        utils.permutations("", "1234", pandigitals);

        //find the ones who can be written as "a * b = c"
        HashSet<Integer> sums = new HashSet<>();

        for (int pan : pandigitals) {
            String panString = String.valueOf(pan);
            int[] panArray = new int[panString.length() + 2];
            int a;
            int b;
            int c;
        }
    }

    public static void euler35() {
        // TODO code application logic here
        HashSet<Long> primes = new HashSet<>();
        for (long i = 3; i < 1000000; i += 2) {
            if (String.valueOf(i).contains("0")) {
                continue;
            }
            if (i >= 100000 && i < 1000000) {
                if (utils.isPrime(i) && utils.isPrime(utils.rotate(i)) && utils.isPrime(utils.rotate(utils.rotate(i))) && utils.isPrime(utils.rotate(utils.rotate(utils.rotate(i)))) && utils.isPrime(utils.rotate(utils.rotate(utils.rotate(utils.rotate(i))))) && utils.isPrime(utils.rotate(utils.rotate(utils.rotate(utils.rotate(utils.rotate(i))))))) {
                    primes.add(i);
                }
            }
            if (i >= 10000 && i < 100000) {
                if (utils.isPrime(i) && utils.isPrime(utils.rotate(i)) && utils.isPrime(utils.rotate(utils.rotate(i))) && utils.isPrime(utils.rotate(utils.rotate(utils.rotate(i)))) && utils.isPrime(utils.rotate(utils.rotate(utils.rotate(utils.rotate(i)))))) {
                    primes.add(i);
                }
            }
            if (i >= 1000 && i < 10000) {
                if (utils.isPrime(i) && utils.isPrime(utils.rotate(i)) && utils.isPrime(utils.rotate(utils.rotate(i))) && utils.isPrime(utils.rotate(utils.rotate(utils.rotate(i))))) {
                    primes.add(i);
                }
            }
            if (i >= 100 && i < 1000) {
                if (utils.isPrime(i) && utils.isPrime(utils.rotate(i)) && utils.isPrime(utils.rotate(utils.rotate(i)))) {
                    primes.add(i);
                }
            }
            if (i >= 10 && i < 100) {
                if (utils.isPrime(i) && utils.isPrime(utils.rotate(i))) {
                    primes.add(i);
                }
            }
            if (i < 10 && utils.isPrime(i)) {
                primes.add(i);
            }
        }
        primes.add(Long.valueOf(2));
        System.out.print(primes.size());
    }
    
    public static void euler54() throws FileNotFoundException, IOException {
        File euler54 = new File("C:\\Users\\pompous\\Documents\\NetBeansProjects\\ProjectEuler\\src\\projecteuler\\extras\\euler54.txt");
        BufferedReader reader = new BufferedReader(new FileReader(euler54.getAbsoluteFile()));
        
        String allHands = "";
        String line;
        int hand1wins = 0;
        int hand2wins = 0;
        int index = 15;
        Pattern p = Pattern.compile(".*\\s.*\\s.*\\s.*\\s.*\\s.*");
        String[] hands = new String[2000];
        
        //allHands gets formatted hands data
        while ((line = reader.readLine()) != null) {
            allHands += line + " " + "\n";
        }
        
        //KQJA replaced with 11 12 13 1
        allHands = allHands.replaceAll("J", "11");
        allHands = allHands.replaceAll("Q", "12");
        allHands = allHands.replaceAll("K", "13");
        allHands = allHands.replaceAll("A","1");

        
        int arrayIndex = 0;
        
        while (allHands.length() >= 15) {
            Matcher m = p.matcher(allHands.substring(0, index));
            boolean b = m.matches();
            if (b) {
                hands[arrayIndex] = allHands.substring(0, index - 1);
                arrayIndex++;
                allHands = allHands.replace(allHands.substring(0, index), "");
                index = 15;
            }   else {
                index++;
            }
        }
        System.out.print(hands[1999]);
    }
    
    public static void euler59() throws FileNotFoundException, IOException {
        File euler59 = new File("C:\\Users\\pompous\\Documents\\NetBeansProjects\\ProjectEuler\\src\\projecteuler\\extras\\euler59.txt");
        BufferedReader reader = new BufferedReader(new FileReader(euler59.getAbsoluteFile()));
        
        String in = reader.readLine();
        String inString = in;
        
        //inLetters is an array containing all of the encrypted characters
        String[] inLetters = inString.split(",");   
        
        //inNumbers is an array containing all of the encrypted characters' ascii values
        int[] inNumbers = new int[inLetters.length];
        for (int i = 0; i <= inLetters.length - 1; i++) {
            inNumbers[i] = Integer.valueOf(inLetters[i]);
        }
        
        // for ascii values in outNumbers
        Integer[] outNumbers = new Integer[inLetters.length];
        String[] outLetters = new String[outNumbers.length];
        
        int keyIndex = 0;
        String key = "aaa";
        int sum = 0;
        
        while (!key.equals("")) {
            
            //outNumbers = XOR'ed ascii values
            for (int i = 0; i <= outNumbers.length - 1; i++) {
                outNumbers[i] = inNumbers[i] ^ (int)key.charAt(keyIndex);
                keyIndex++;
                if (keyIndex == 3) keyIndex = 0;
            }
            
            for (int i = 0; i <= outLetters.length - 1; i++) {
                outLetters[i] = String.valueOf(Character.toChars(outNumbers[i]));
            }
            
            String test = "";
            
            for (int i = 0; i <= outLetters.length - 1; i++) {
                test += outLetters[i];
            }
            
            if (test.contains(" the ")) {
                System.out.print(key + " + " + test);
                for (int i = 0; i <= outNumbers.length - 1; i++) {
                    sum += outNumbers[i];
                }
                key = "";
                System.out.print(sum);
            }   else {
                key = utils.keyIncrementer(key);
                keyIndex = 0;
            }
        }
    }
    

    public static class utils {

        //general functions
        public static long numberOfFactors(long a) {
            int count = 0;
            for (long i = 1; i <= Math.sqrt(a); i++) {
                if (a % i == 0) {
                    count++;
                }
            }
            return count;
        }

        public static boolean isAbundant(int a) {
            int b = 1;
            for (int i = 2; i <= a / 2; i++) {
                if (a % i == 0) {
                    b += i;
                }
            }
            return b > a;
        }

        public static boolean containsUniqueDigits(long a) {
            if (a == 0) {
                return true;
            }
            HashSet<Long> digits = new HashSet<>();

            do {
                long digit = a % 10;
                if (digits.contains(digit)) {
                    return false;
                } else {
                    digits.add(digit);
                    a = a / 10;
                }
            } while (a >= 10);

            return !digits.contains(a);
        }

        public static boolean isPandigital(long a) {
            //n reflects the number of a's digits
            int n = String.valueOf(a).length();

            //if n >= 10, then a cannot be considered 1 to n pandigital: e.g. when n = 10; a must contain 1 only once, and cannot contain 1 twice for the number 10
            if (n > 9) {
                return false;
            }

            //if a contains a 0, then a is not 1 to n pandigital: e.g. a three-digit number containing 0 (e.g. "310") cannot contain 1,2,3
            if (String.valueOf(a).contains("0")) {
                return false;
            }

            //from one to n, check to see if a contains i
            for (int i = 1; i <= n; i++) {
                if (!String.valueOf(a).contains(String.valueOf(i))) {
                    return false;
                }
            }
            return true;
        }

        /**
         * shows whether or not "a" can be expressed as the sum of all of its
         * digits raised to the fifth power
         *
         * @param a
         * @return
         */
        public static boolean digitFifth(int a) {
            String number = String.valueOf(a);
            int power = 0;
            for (int i = 0; i < number.length(); i++) {
                power += Math.pow(Integer.valueOf(number.substring(i, i + 1)), 5);
            }
            return (a == power);
        }

        //TODO: test this
        private static HashSet<Long> returnFactors(long a) {
            int incrementer = 1;
            if (a % 2 != 0) {
                incrementer = 2;
            }
            HashSet<Long> list = new HashSet<>();
            for (int i = 1; i <= a / 2; i += incrementer) {
                if (a % i == 0) {
                    list.add(Long.valueOf(i));
                }
            }
            list.add(a);
            return list;
        }

        //public static boolean isCurious(int a) {
        
        public static String insertSubstring(String s, String sub, int index) {
            String first = s.substring(0, index);
            String last = s.substring(index);
            return first + sub + last;
        }
        
        
        public static boolean isPalindrome(String s) {
            char firstDigit = s.charAt(0);
            char lastDigit = s.charAt(s.length() - 1);
            String nextS;

            if (firstDigit != lastDigit)  return false;
            
            if (s.length() == 2 || s.length() == 1) {
                return true;
            } else {
                nextS = s.substring(1, s.length() - 1);
                return (isPalindrome(nextS));
            }
        }
        
        public static boolean isPrime(long n) {
            //check if n is a multiple of 2
            if (n % 2 == 0) {
                return false;
            }
            //if not, then check to see if n has any odd factors
            for (int i = 3; i * i <= n; i += 2) {
                if (n % i == 0) {
                    return false;
                }
            }
            return true;
        }

        public static String keyIncrementer(String k) {
            int k0 = (int) k.charAt(0);
            int k1 = (int) k.charAt(1);
            int k2 = (int) k.charAt(2);
            
            //k2 check
            if (k2 != 122) {
                k2++;
            }   else { // "--z"
                k2 = 97;
                if (k1 != 122) {
                    k1++;
                }   else { // "-zz"
                    k1 = 97;
                    if (k0 != 122) {
                        k0++;
                    }   else { // "zzz"
                        return "";
                    }
                }
            }
            
            String newK = Character.toString((char)(k0)) + Character.toString((char)(k1)) + Character.toString((char)(k2));
            return newK;
        }
        




        public static void permute(String beginningString, String endingString, HashSet a) {
            if (endingString.length() <= 1) {
                a.add(beginningString + endingString);
            } else {
                for (int i = 0; i < endingString.length(); i++) {
                    String newString = endingString.substring(0, i) + endingString.substring(i + 1);
                    permute(beginningString + endingString.charAt(i), newString, a);
                }
            }
        }

        public static void permutations(String beginningString, String endingString, HashSet<Integer> a) {
            if (endingString.length() <= 1) {
                a.add(Integer.valueOf(beginningString + endingString));
            } else {
                for (int i = 0; i < endingString.length(); i++) {
                    String newString = endingString.substring(0, i) + endingString.substring(i + 1);
                    permutations(beginningString + endingString.charAt(i), newString, a);
                }
            }
        }

        /**
         * takes an integer n and returns one of its permutations; e.g. 4912 ->
         * 9124
         *
         * @param n
         * @return
         */
        public static long rotate(long n) {
            String stringN = String.valueOf(n);
            char[] arrayN = new char[stringN.length()];

            for (int i = 0; i < stringN.length(); i++) {
                arrayN[i] = stringN.charAt(i);
            }

            char store = arrayN[0];
            for (int i = 0; i < arrayN.length - 1; i++) {
                arrayN[i] = arrayN[i + 1];
            }
            arrayN[arrayN.length - 1] = store;

            stringN = "";
            for (int i = 0; i < arrayN.length; i++) {
                stringN += arrayN[i];
            }
            return Integer.valueOf(stringN);
        }
    }
}
