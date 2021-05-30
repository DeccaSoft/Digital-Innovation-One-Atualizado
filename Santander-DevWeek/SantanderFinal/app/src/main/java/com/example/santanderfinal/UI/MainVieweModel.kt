package com.example.santanderfinal.UI

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.santanderfinal.data.Conta
import com.example.santanderfinal.data.local.FakeData

class MainViewModel: ViewModel(){
    private val mutableLiveData: MutableLiveData<Conta> = MutableLiveData()
    fun buscarContaCliente() : LiveData<Conta> {
        mutableLiveData.value = FakeData().getLocalData()
        return mutableLiveData
    }
}