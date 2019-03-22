package com.company;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {

    public static void main(String[] args) {
	    Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        Pattern pattern = Pattern.compile("[\\d\\.]+");
        Matcher matcher = pattern.matcher(input);

        Pattern patternString = Pattern.compile("[+-]+]");
        Matcher matcherString = patternString.matcher(input);

        ArrayList<String> arrayListInteger = new ArrayList<>();
        ArrayList<String> arrayListString = new ArrayList<>();

        while (matcher.find()){
            arrayListInteger.add(matcher.group());
        }

        while (matcherString.find()){
            arrayListString.add(matcher.group());
        }

        BigDecimal totalSum = new BigDecimal(arrayListInteger.get(0));

        for (int i = 0; i < arrayListString.size(); i++) {
            if (arrayListString.get(i).equals("+")) {
                totalSum = totalSum.add(new BigDecimal(arrayListInteger.get(i+1)));
            }else if (arrayListString.get(i).equals("-")) {
                totalSum = totalSum.subtract(new BigDecimal(arrayListInteger.get(i+1)));
            }
        }
        System.out.println(totalSum);
    }
}
