package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int[] numbers = new int[n];
        int Sum = 0;

        for (int i = 0; i < numbers.length; i++)
        {
            System.out.println("Please enter number");
            numbers[i] = input.nextInt();
        }

        for (int i = 0; i < numbers.length; i++)
        {
            Sum += numbers[i];
        }

        System.out.print(Sum);
    }
}
