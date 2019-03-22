package com.company;

import java.util.Scanner;
import java.util.regex.*;

public class Main {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String regex = "([-._0-9a-zA-Z]+@)([a-zA-Z.-]+)[.]";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(input.nextLine());
        while (matcher.find()) {
            System.out.println(matcher.group(1)+matcher.group(2));
        }
    }
}
