package com.company;

import java.util.*;
import java.util.regex.*;

public class Main {

    public static void main(String[] args) {
        Scanner input= new Scanner(System.in);
        String text=input.nextLine().toLowerCase();
        String word=input.nextLine();
        int lengthWord=word.length();
        int br=0;
        for (int i = 0; i < text.length()-lengthWord; i++) {
            if (word.equals(text.substring(i,i+lengthWord))){
                br++;
            }
        }
        System.out.println(br);;
    }
}
