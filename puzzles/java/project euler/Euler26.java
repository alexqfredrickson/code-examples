/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projecteuler;

import java.math.BigDecimal;

/**
 *
 * @author thepompano
 */
public class Euler26 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        int count;
        int largestReciprocalCycle = 6;
        int largestRepeatingI = 7;
        
        int magicNumber;
        for (int k = 0; k <= 10; k++) {
            magicNumber = k;
            for (int i = 1; i < 1000; i++) {
                count = 1;
                BigDecimal one = new BigDecimal("1");
                BigDecimal q = new BigDecimal(String.valueOf(i));
                BigDecimal decimal = one.divide(q, 200, BigDecimal.ROUND_DOWN);

                String decString = decimal.toString();

                // cut off the 0.000*'s
                if (i <= 10) {
                    decString = decString.replace(decString.substring(0, 2), "");
                } else if (i > 10 && i <= 100) {
                    decString = decString.replace(decString.substring(0, 3), "");
                } else if (i > 100 && i <= 1000) {
                    decString = decString.replace(decString.substring(0, 4), "");
                }

                //get first substring of decString, starting with index 0
                String substring = decString.substring(magicNumber, magicNumber + count);
                //get the index of the next appearance of that substring
                int index = decString.indexOf(substring, count);
                //if it is found, search for the next appearance of the substring between the two appearances of the character (in this case CARPENTER)
                while (index >= count) {
                    if (count == index) {
                        break;
                    }
                    count++;
                    substring = decString.substring(0, count);
                    index = decString.indexOf(substring, count);
                }

                //log the repeating decimal thang, but not if it's a shitty one
                if (substring.length() > largestReciprocalCycle
                        && !(substring.charAt(0) == substring.charAt(1))
                        && !(substring.substring(0, 2).equals(substring.substring(2, 4)))) {
                    largestReciprocalCycle = substring.length();
                    largestRepeatingI = i;
                }

                //print interesting results
                if (substring.length() > largestReciprocalCycle) {
                    System.out.println("Substring is: " + substring + ". Fraction is 1/" + q + ".");
                }
            }
        }
        
        System.out.println(largestRepeatingI);
        System.out.println(largestReciprocalCycle);
    }

}
