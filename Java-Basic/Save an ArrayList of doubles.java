package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<Double> doubles = new ArrayList<Double>() {{
            addAll(Arrays.asList(5.8, 7.9, 6.01, 5.7));
        }};
        //saveDoubles
        try(ObjectOutputStream destination = new ObjectOutputStream(new FileOutputStream("doubles.list"))) {
            for (Double aDouble : doubles) {
                destination.writeDouble(aDouble);
            }
        } catch (FileNotFoundException FNOE) {
            FNOE.printStackTrace();
        } catch (IOException IO) {
            IO.printStackTrace();
        }
        //loadDoubles
        try(ObjectInputStream source = new ObjectInputStream(new FileInputStream("doubles.list"))) {
            for (int i = 0; i < doubles.size(); i++) {
                System.out.println(source.readDouble());
            }
        } catch (FileNotFoundException FNOE) {
            FNOE.printStackTrace();
        } catch (IOException IO) {
            IO.printStackTrace();
        }
    }
}
