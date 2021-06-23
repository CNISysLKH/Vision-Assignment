using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ImageProcessing;
namespace CniVision
{

    public static class CniMerge
    {

        public static CogToolGroup cMergeRegions = null;             // 병합 이미지의 겹칠 영역

        /// <summary>
        /// 이미지 병합 함수
        /// </summary>
        /// <param name="images">이미지 배열</param>
        /// <returns></returns>
        public static Bitmap Merge(List<Bitmap> images)
        {

            if (images == null || images.Count < 1) return null;     // images null 및 개수 체크 null 또는 없으면 그대로 null 리턴

            if (images.Count == 1)         // images의 개수가 1개면 그대로 리턴
            {
                return images[0];
            }


            float fWidth = 0;            // 전체 이미지 가로 크기
            float fHeight = 0;           // 전체 이미지 세로 크기




            // 병합 이미지의 해상도 구함
            foreach (Bitmap image in images)
            {
                fWidth += image.Width;
                fHeight = fHeight < image.Height ? image.Height : fHeight;
            }


            Bitmap img = new Bitmap((int)fWidth, (int)fHeight);                  // 반환 이미지 변수


            if (images.Count > 1)               // images의 개수가 2개 이상일 때 병합
            {

                // 이미지 병합 부분
                using (Graphics graphic = Graphics.FromImage(img))
                {
                    float fPosX = 0;

                    foreach (Bitmap image in images)
                    {
                        graphic.DrawImage(image, fPosX, 0, image.Width, image.Height);       // 옆으로 이어 붙임
                        fPosX = image.Width;
                    }
                }

            }
            return img;
        }


        // ICogImage 리스트를 Bitmap 리스트로 변환 함수
        public static List<Bitmap> ICogImageToBitmapConvert(List<ICogImage> images)
        {
            List<Bitmap> bitmapList = new List<Bitmap>();

            foreach (ICogImage image in images)
            {
                bitmapList.Add(image.ToBitmap());
            }

            return bitmapList;
        }

        // 겹칠 이미지 제거 후 이미지 반환
        public static List<ICogImage> ImageClipConvert(List<ICogImage> images)
        {
            List<ICogImage> lstImage = new List<ICogImage>();

            for (int i = 0; i < images.Count; ++i)
            {
                (cMergeRegions.Tools[i] as CogIPOneImageTool).InputImage = images[i];
                cMergeRegions.Tools[i].Run();
                lstImage.Add((cMergeRegions.Tools[i] as CogIPOneImageTool).OutputImage);
            }

            return lstImage;
        }

        // 이미지 겹칠 영역 불러오기
        public static void LoadMergeRegion()
        {
            object objTG = CniToolProcess.LoadTool("MergeRegionsToolGroup");

            if (objTG is CogToolGroup)
            {
                cMergeRegions = objTG as CogToolGroup;
            }

        }
        // 이미지 겹칠 영역 저장하기
        public static void SaveMergeRegion()
        {
            CniToolProcess.SaveTool(cMergeRegions, "MergeRegionsToolGroup");
        }

    }
}
