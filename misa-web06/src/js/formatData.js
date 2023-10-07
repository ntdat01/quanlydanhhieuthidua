import misaEnum from './enum';
var formatInactive = function (value) {
    switch (value) {
        case misaEnum.Inactive.Active:
            return 'Sử dụng'
        case misaEnum.Inactive.InActive:
            return 'Ngừng sử dụng'
    }
}

var formatIsSystem = function (value) {
    switch (value) {
        case misaEnum.IsSystem.IsSystem:
            return 'Có'
        case misaEnum.IsSystem.IsNotSystem:
            return 'Ngừng sử dụng'
    }
}

var formatMovementType = function (value) {
    switch (value) {
        case misaEnum.MovementType.Regular:
            return 'Thường xuyên'
        case misaEnum.MovementType.Periordic:
            return 'Theo đợt'
        case misaEnum.MovementType.All:
            return 'Thường xuyên và theo đợt'
    }
}

var formatRewardLevel = function (value) {
    switch (value) {
        case misaEnum.RewardLevel.NationalLevel:
            return 'Cấp nhà nước'
        case misaEnum.RewardLevel.ProvincialLevel:
            return 'Cấp Tỉnh/tương đương'
        case misaEnum.RewardLevel.DistrictLevel:
            return 'Cấp Huyện/tương đương'
        case misaEnum.RewardLevel.CommunalLevel:
            return 'Cấp Xã/tương đương'
    }
}

var formatRewardObject = function (value) {
    switch (value) {
        case misaEnum.RewardObject.Personal:
            return 'Cá nhân'
        case misaEnum.RewardObject.Group:
            return 'Tập thể'
        case misaEnum.RewardObject.PersonalAndGroup:
            return 'Cá nhân và Tập thể'
        case misaEnum.RewardObject.Family:
            return 'Hộ gia đình'
    }
}
const formatData = { formatInactive, formatIsSystem, formatMovementType, formatRewardLevel, formatRewardObject }
export default formatData;
