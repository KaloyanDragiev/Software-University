package com.company;

import java.io.*;

public class Main {

    public static void main(String[] args) {
        try (BufferedReader reader = new BufferedReader(new FileReader("word.txt"));
             PrintWriter writer = new PrintWriter(new FileWriter("count-chars.txt"))) {
            String str = reader.readLine();
            while (str != null){
                int sum = 0;
                int sum2 = 0;
                int sum3 = 0;
                for (int i = 0; i < str.length(); i++) {
                    //a, e, i, o, u
                    if (str.charAt(i) == 'a' || str.charAt(i) == 'e' ||
                        str.charAt(i) == 'i' || str.charAt(i) == 'o' ||
                        str.charAt(i) == 'u'){
                        sum++;
                    }
                    //all others
                    if (str.charAt(i) != 'a' || str.charAt(i) != 'e' ||
                        str.charAt(i) != 'i' || str.charAt(i) != 'o' ||
                        str.charAt(i) != 'u'){
                        sum2++;
                    }
                    //!,.?
                    if (str.charAt(i) != '!' || str.charAt(i) != ',' ||
                        str.charAt(i) != '.' || str.charAt(i) != '?'){
                        sum2++;
                    }
                }
                writer.write(String.format("Vowels: %d\nConsonants: %d\nPunctuation: %d", sum, sum2, sum3));
                str = reader.readLine();
            }
        } catch (IOException IO) {
            System.out.println("CAUGHT");
        }

    }
}
