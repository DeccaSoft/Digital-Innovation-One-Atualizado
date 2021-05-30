package com.example.myfirstapplication

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //Declaração de Variáveis
        val constante : String = "CONSTANTE"    //Valor Imutável
        var variavel: String = "Variável"       //Valor Mutável
        //Segurança Nula...
        val podeSerNula : String? = null

        //Condicionais
        val idade : Int = 21
        var resposta : String = ""

        if (idade < 18){
            resposta = "Menor de Idade"
        }else{
            resposta = "Maior de Iade"
        }

        //Outra forma mais resumida...
        var podeVotar : String = if (idade >= 16){
            "Pode Votar"
        }else{
            "NÃO pode votar"
        }

        //Condicional com o when...
        var absoluta = when{
            idade >= 21 -> "Maioridade Absoluta"
            else -> "Ainda NÃO tem maioridade absoluta"
        }

        //Funções...
        minhaIdade()

        //Classes
        val medicamento = Medicamento("Texto Fórmula", "2 x ao Dia!")
        medicamento.formula = "Fórmula2"
    }

    fun minhaIdade() : Int{
        return 45
    }

    //Outra forma mais Resumida...
    fun idadeFilho() : Int = 15

}