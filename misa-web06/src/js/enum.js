const Inactive = {
    // <summary>
    // Sử dụng
    // </summary>
    // Created by: ntdat (11/08/2023)
    Active: 1,

    // <summary>
    // Ngừng sử dụng
    // </summary>
    // Created by: ntdat (11/08/2023)
    InActive: 0,
};

const IsSystem = {
    // <summary>
    // Có
    // </summary>
    // Created by: ntdat (11/08/2023)
    IsSystem: 1,

    // <summary>
    // Không
    // </summary>
    // Created by: ntdat (11/08/2023)
    IsNotSystem: 0
}

const MovementType = {
    // <summary>
    // Thường xuyên
    // </summary>
    // Created by: ntdat (11/08/2023)
    Regular: 1,

    // <summary>
    // Theo đợt
    // </summary>
    // Created by: ntdat (11/08/2023)
    Periordic: 2,

    // <summary>
    // Thường xuyên và Theo đợt
    // </summary>
    // Created by: ntdat (11/08/2023)
    All: 0
}
const RewardLevel = {
    // <summary>
    // Cấp Nhà nước
    // </summary>
    // Created by: ntdat (11/08/2023)
    NationalLevel: 1,

    // <summary>
    // Cấp Tỉnh/tương đương
    // </summary>
    // Created by: ntdat (11/08/2023)
    ProvincialLevel: 2,

    // <summary>
    // Cấp Huyện/tương đương
    // </summary>
    // Created by: ntdat (11/08/2023)
    DistrictLevel: 3,

    // <summary>
    // Cấp Xã/tương đương
    // </summary>
    // Created by: ntdat (11/08/2023)
    CommunalLevel: 4
}
const RewardObject = {
    // <summary>
    // Cá nhân
    // </summary>
    // Created by: ntdat (11/08/2023)
    Personal: 1,

    // <summary>
    // Tập thể
    // </summary>
    // Created by: ntdat (11/08/2023)
    Group: 2,

    // <summary>
    // Cá nhân và Tập thể
    // </summary>
    // Created by: ntdat (11/08/2023)
    PersonalAndGroup: 3,

    // <summary>
    // Hộ gia đình
    // </summary>
    // Created by: ntdat (11/08/2023)
    Family: 4
}
const misaEnum = {
    Inactive,
    IsSystem,
    MovementType,
    RewardLevel,
    RewardObject
}
export default misaEnum;
