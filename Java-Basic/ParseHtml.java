package com.company;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {

    public static void main(String[] args) {
        Scanner scanner  = new Scanner(System.in);
        String str  = scanner.nextLine();
        String firstPattern = "\\<\\s*([\\w]+)\\s+content\\s*\\=\\s*\"(.+)\\s*\"\\s*\\/\\>";
        String secondPattern = "\\<\\s*([\\w]+)\\s+value\\s*\\=\\s*\"([0-9]+)\"\\s*content\\s*\\=\\s*\"(.+)\\s*\"\\s*\\/\\s*\\>";

        Pattern inverseReversePattern = Pattern.compile(firstPattern);
        Pattern repeatPattern = Pattern.compile(secondPattern);

        while (!str.equals("<stop/>")) {
            Matcher inverseReverseMatcher = inverseReversePattern.matcher(str);
            Matcher repeatMatcher = repeatPattern.matcher(str);

            if (inverseReverseMatcher.find()) {
                if (inverseReverseMatcher.group(1).equals("inverse")) {
                    System.out.println(inverseReverseMatcher.group(2).toLowerCase());
                    //<inverse content="HelloWorlD"/><stop/>
                    //<reverse content="helloworld"/><stop/>
                } else if (inverseReverseMatcher.group(1).equals("reverse")) {
                    String reversedString = "";
                    for(int i=inverseReverseMatcher.group(2).length(); i>0; i--) {
                        reversedString += inverseReverseMatcher.group(2).charAt(i-1);
                    }
                    System.out.println(reversedString);
                }
            }

            else if (repeatMatcher.find()) {
                for (int i = 0; i <= repeatMatcher.group(2).length(); i++) {
                    System.out.println(repeatMatcher.group(3));
                    //<repeat value="2" content="helloworld"/><stop/>
                }
            }
            str = scanner.nextLine();
        }

    }
}
