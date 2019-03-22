package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();
        double sumone = Math.pow((a*a + b*b)/(a*a - b*b),((a+b+c)/Math.sqrt(c)));
        double sumtwo = Math.pow((a*a + b*b - c*c*c),(a-b));
        double sumthree = (a+b+c)/3 - (sumone+sumtwo)/2;
        if (sumthree<0)
        {
        sumthree *= -1;
        }
        if (sumone!=0 || sumtwo!=0 || sumthree!=0) {
            System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", sumone, sumtwo, sumthree);
        }
        else if(sumone==0) {
            System.out.printf("F1 result: NaN; F2 result: %.2f; Diff: %.2f",sumtwo, sumthree);
        }
        else if(sumtwo==0) {
            System.out.printf("F1 result: %.2f; F2 result: NaN; Diff: %.2f", sumone, sumthree);
        }
        else if(sumthree==0) {
            System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: NaN", sumone, sumtwo);
        }
        else if(sumone==0 && sumtwo==0) {
            System.out.printf("F1 result: NaN; F2 result: NaN; Diff: %.2f", sumthree);
        }
        else if(sumtwo==0 && sumthree==0) {
            System.out.printf("F1 result: %.2f; F2 result: NaN; Diff: NaN", sumone);
        }
        else if(sumthree==0 && sumone==0) {
            System.out.printf("F1 result: NaN; F2 result: %.2f; Diff: NaN", sumtwo);
        }
        else if(sumone==0 && sumtwo==0 && sumthree==0) {
            System.out.printf("F1 result: NaN; F2 result: NaN; Diff: NaN");
        }
    }
}