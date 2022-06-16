/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package server;

import client.ConnectClient;
import client.Spice;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author student
 */
public class ConectServer {

    ServerSocket listener;

    static ArrayList<Spice> ListSPICE = new ArrayList<>();

    /**
     * @param args the command line arguments
     */
    public ConectServer()

    {
        //אתחול הליסט -הדטה ביסך
        Spice db=new Spice("פפריקה", 5);
        ListSPICE.add(db);
         Spice d=new Spice("מרק עוף", 5);
        ListSPICE.add(d);
         Spice b=new Spice("כמון", 5);
        ListSPICE.add(b);
         Spice dab=new Spice("כרכום", 5);
        ListSPICE.add(dab);
        try {
            ServerSocket listener = new ServerSocket(4500);

            while (true) {
                Socket conection = listener.accept();
                 ClientHedler clientH = new ClientHedler(conection);
             
              
            }
        } catch (IOException e) {
            System.out.println("server shut doun with eror:" + e);
        }
        

    }
//     public ArrayList<Spice> ReadFromeServer() {
//        try {
//            return (ArrayList<Spice>) fromServer();
//        } catch (IOException ex) {
//            Logger.getLogger(ConnectClient.class.getName()).log(Level.SEVERE, null, ex);
//        } catch (ClassNotFoundException ex) {
//            Logger.getLogger(ConnectClient.class.getName()).log(Level.SEVERE, null, ex);
//        }
//        return null;
//    }
    public static synchronized boolean  ifQtY(ArrayList<Spice> Order){
        for(Spice item:Order)
        {
            for(Spice it:ListSPICE)
            {
                if(item.getName().equals(it.getName())&&item.getAmount()<=it.getAmount())
                {
                    //לעדכן נכון את הכמות
                    it.setAmount(it.getAmount()-item.getAmount());
                    break;
                }
                else if(item.getName().equals(it.getName())&&item.getAmount()>it.getAmount())
                    return false;
            }
            
        }
        return true;
    }

 public static void main(String [] args){
        new ConectServer();
    }

}