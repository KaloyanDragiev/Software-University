package com.company;

import java.util.Scanner;
import java.util.regex.*;

public class Main {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String regex = "[a-zA-Z]+";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(input.nextLine());
        while (matcher.find()) {
            System.out.print(matcher.group() + " ");
        }
    }
}
