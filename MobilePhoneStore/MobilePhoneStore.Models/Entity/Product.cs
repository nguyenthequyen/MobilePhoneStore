using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class Product : IBaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// Thương hiệu
        /// </summary>
        public string Trademark { get; set; }
        public string Model { get; set; }
        public float CameraFront { get; set; }
        public float CameraBack { get; set; }
        public bool LightFlash { get; set; }
        public string VideoCall { get; set; }
        public string Film { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        /// <summary>
        /// Cân nặng
        /// </summary>
        public float Weigh { get; set; }
        public string Size { get; set; }
        /// <summary>
        /// Tên chip
        /// </summary>
        public string ChipName { get; set; }
        /// <summary>
        /// Tốc độ chip
        /// </summary>
        public float ChipSpeed { get; set; }
        /// <summary>
        /// Loại lõi chip
        /// </summary>
        public string ChipCoreType { get; set; }
        /// <summary>
        /// Chip đồ họa
        /// </summary>
        public string GPU { get; set; }
        /// <summary>
        /// Dung lượng PIN
        /// </summary>
        public int BatteryCapacity { get; set; }
        /// <summary>
        /// Loại PIN
        /// </summary>
        public string TypePIN { get; set; }
        /// <summary>
        /// Kết nối dữ liệu
        /// </summary>
        public string DataConnect { get; set; }
        public bool Support4G { get; set; }
        public string TypeSIM { get; set; }
        public int NumberSIM { get; set; }
        public string Wifi { get; set; }
        public string GPS { get; set; }
        public string Bluetooth { get; set; }
        /// <summary>
        /// Cổng sạc
        /// </summary>
        public string ChargingPort { get; set; }
        /// <summary>
        /// Jack tai nghe
        /// </summary>
        public string HeadphoneJack { get; set; }
        /// <summary>
        /// Xem phim
        /// </summary>
        public string WatchMovie { get; set; }
        /// <summary>
        /// Nghe nhạc
        /// </summary>
        public string ListenMusic { get; set; }
        /// <summary>
        /// Ghi âm
        /// </summary>
        public bool SoundRecording { get; set; }
        public bool FMRadio { get; set; }
        /// <summary>
        /// Stock Keeping Unit
        /// </summary>
        public string SKU { get; set; }
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
