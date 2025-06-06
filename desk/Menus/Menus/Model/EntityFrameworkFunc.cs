﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menus.Model
{
    class EntityFrameworkFunc
    {
        bancoMainEntities1 ht2 = new bancoMainEntities1();
        public List<dynamic> getSharedNotes(int userId)
        {
            var content = (from str in ht2.TB_SHARE
                           join send in ht2.TB_USER on str.SENDER_INT_ID equals send.USER_INT_ID
                           join recipient in ht2.TB_USER on str.RECIPIENT_INT_ID equals recipient.USER_INT_ID
                           join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.STR_INT_ID
                           join notaChild in ht2.TB_NOTA_STR on nota.STR_INT_ID equals notaChild.STR_INT_ID
                           group nota by new { str.SHARE_INT_ID, send.USER_STR_NOME, recipient.USER_INT_ID } into g
                           where userId == g.Key.USER_INT_ID
                           select new
                           {
                               shareId = g.Key.SHARE_INT_ID,
                               senderName = g.Key.USER_STR_NOME
                           });

            return content.ToList<dynamic>();
        }

        public dynamic getNoteData(int shareId)
        {
            var content = (from str in ht2.TB_SHARE
                           join send in ht2.TB_USER on str.SENDER_INT_ID equals send.USER_INT_ID
                           join recipient in ht2.TB_USER on str.RECIPIENT_INT_ID equals recipient.USER_INT_ID
                           join nota in ht2.TB_NOTA on str.NOTA_INT_ID equals nota.STR_INT_ID
                           join notaChild in ht2.TB_NOTA_STR on nota.STR_INT_ID equals notaChild.STR_INT_ID
                           where shareId == str.SHARE_INT_ID
                           select new
                           {
                               notaId = nota.NOTA_INT_ID,
                               notaChildId = nota.STR_INT_ID,
                               notaTitle = notaChild.STR_STR_TITLE,
                               notaContent = notaChild.STR_STR_PATH,
                               notaFacul = nota.FAC_INT_ID,
                               notaCur = nota.CUR_INT_ID,
                               notaMat = nota.MAT_INT_ID,
                               senderName = send.USER_STR_NOME
                           }).FirstOrDefault();

            return content;
        }

        public List<dynamic> getCurso(int curId)
        {
            List<dynamic> entryPoint = (from str in ht2.TB_NOTA_STR
                                        join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                        where curId == nota.CUR_INT_ID
                                        group nota by new { nota.STR_INT_ID, str.STR_STR_TITLE } into g

                                        select new
                                        {
                                            notaTitle = g.Key.STR_STR_TITLE,
                                            notaId = g.Key.STR_INT_ID,
                                        }).ToList<dynamic>();
            return entryPoint;    
        }

        public List<dynamic> getCurso(int curId, string searchContent)
        {
            List<dynamic> entryPoint = (from str in ht2.TB_NOTA_STR
                                        join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                        where curId == nota.CUR_INT_ID
                                        group nota by new { nota.STR_INT_ID, str.STR_STR_TITLE } into g

                                        select new
                                        {
                                            notaTitle = g.Key.STR_STR_TITLE,
                                            notaId = g.Key.STR_INT_ID,
                                        }).Where(c => c.notaTitle.Contains(searchContent)).ToList<dynamic>();
            return entryPoint;
        }

        public List<dynamic> getMateria(int matId)
        {
            List<dynamic> entryPoint = (from str in ht2.TB_NOTA_STR
                          join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                          where matId == nota.MAT_INT_ID
                          group nota by new { nota.STR_INT_ID, str.STR_STR_TITLE } into g
                          select new
                          {
                              notaTitle = g.Key.STR_STR_TITLE,
                              notaId = g.Key.STR_INT_ID,
                          }).ToList<dynamic>();

            return entryPoint;
        }

        public List<dynamic> getMateria(int matId, string searchContent)
        {
            List<dynamic> entryPoint = (from str in ht2.TB_NOTA_STR
                                        join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                        where matId == nota.MAT_INT_ID
                                        group nota by new { nota.STR_INT_ID, str.STR_STR_TITLE } into g
                                        select new
                                        {
                                            notaTitle = g.Key.STR_STR_TITLE,
                                            notaId = g.Key.STR_INT_ID,
                                        }).Where(c => c.notaTitle.Contains(searchContent)).ToList<dynamic>();

            return entryPoint;
        }

        public List<dynamic> getFaculdade(int facId)
        {
            List<dynamic> entryPoint = (from str in ht2.TB_NOTA_STR
                                        join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                        where facId == nota.FAC_INT_ID
                                        group nota by new { nota.STR_INT_ID, str.STR_STR_TITLE } into g
                                        select new
                                        {
                                            notaTitle = g.Key.STR_STR_TITLE,
                                            notaId = g.Key.STR_INT_ID,
                                        }).ToList<dynamic>();
            return entryPoint;
        }
        public List<dynamic> getFaculdade(int facId, string searchContent)
        {
            List<dynamic> entryPoint = (from str in ht2.TB_NOTA_STR
                                        join nota in ht2.TB_NOTA on str.STR_INT_ID equals nota.STR_INT_ID
                                        where facId == nota.FAC_INT_ID
                                        group nota by new { nota.STR_INT_ID, str.STR_STR_TITLE } into g
                                        select new
                                        {
                                            notaTitle = g.Key.STR_STR_TITLE,
                                            notaId = g.Key.STR_INT_ID,
                                        }).Where(c => c.notaTitle.Contains(searchContent)).ToList<dynamic>();
            return entryPoint;
        }
    }
}
