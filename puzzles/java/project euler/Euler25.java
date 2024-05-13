/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package euler;

import java.math.BigInteger;

/**
 *
 * @author thepompano
 */
public class Euler25 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        BigInteger f1 = BigInteger.valueOf(1);
        BigInteger f2 = BigInteger.valueOf(1);
        BigInteger fN;
        int term = 2;
        boolean stop = false;

        while (stop == false) {
            fN = f1.add(f2);
            term++;
            if (digitCheck(fN)) {
                System.out.print(term);
                break;
            } else {
                f1 = f2;
                f2 = fN;
            }
        }

    }

    public static boolean digitCheck(BigInteger a) {
        String b = a.toString();
        return (b.length() >= 1000);
    }
}
