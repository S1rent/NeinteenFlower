﻿using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class ManageFlowerHandler
    {
        public void deleteFlowerById(int id)
        {
            FlowerRepository.shared.deleteFlowerById(id);
        }
        public List<MsFlower> GetFlowerList()
        {
            return FlowerRepository.shared.GetFlowerList();
        }
        public bool CheckMemberEmailExist(string email)
        {
            if (MemberRepository.shared.GetMemberByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmployeeEmailExist(string email)
        {
            if (EmployeeRepository.shared.GetEmployeeByEmail(email).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MsEmployee GetEmployeeData(string email)
        {
            return HeaderFooterRepository.shared.GetEmployeeData(email);
        }
    }
}