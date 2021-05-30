package com.example.santanderfinal.data.local

import com.example.santanderfinal.data.Cartao
import com.example.santanderfinal.data.Cliente
import com.example.santanderfinal.data.Conta

class FakeData {
    fun getLocalData(): Conta {
        val cliente = Cliente("André")
        val cartao = Cartao("123456789-0")
        return Conta(
            "445655-4",
            "6552-4",
            "R$ 2.450.80",
            "R$4.120,00",
            cliente,
            cartao
        );
    }
}